using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Lathorva.Common.Authentication.Jwt;
using Lathorva.Common.Repository;
using Lathorva.Common.Repository.Filtering;
using Lathorva.Common.Repository.Models;
using Lathorva.Common.Web.Attributes;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Lathorva.Common.Web
{
    /// <summary>
    /// Base REST Api ctrl, with both JWT authentication and Cookie (using OpenID)
    /// Important! Include IOptions ApiDefaultPaging in startup.cs
    /// TODO, fix 401 statuscode instead of 302 redirect wi
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TName"></typeparam>
    /// <typeparam name="TModel"></typeparam>
    /// <typeparam name="TRepository"></typeparam>
    /// <typeparam name="TFilter"></typeparam>
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtDefaults.SchemeName + "," + OpenIdConnectDefaults.AuthenticationScheme + "," + CookieAuthenticationDefaults.AuthenticationScheme)]
    public abstract class RestApiBaseController<TKey, TName, TModel, TFilter, TRepository> : Controller
        where TKey : IConvertible
        where TModel : class, IEntity<TKey>
        where TRepository : IRepository<TKey, TModel, TFilter>
        where TFilter : IFilterModel
    {
        public TRepository Repository { get; }
        public IPAddress IpAddress => Request.HttpContext.Connection.RemoteIpAddress;
        public RestApiDefaults AppDefaultPaging { get; }
        public ILogger<TName> Logger { get; }

        protected RestApiBaseController(TRepository repository, IOptions<RestApiDefaults> options, ILogger<TName> logger)
        {
            Repository = repository;
            AppDefaultPaging = options.Value;
            Logger = logger;
        }

        [HttpGet("{id}")]
        [ValidateModelState]
        public virtual async Task<IActionResult> Get([FromRoute] TKey id)
        {
            Logger.LogInformation($"Finding resource with id: {id}");
            var result = await new TaskAuditor<TModel>(() => Repository.GetByIdOrDefaultAsync(id), Logger, this).StartAsync();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        [ValidateModelState]
        public virtual async Task<IActionResult> GetAll(TFilter filterModel)
        {
            if (filterModel.Limit == 0) filterModel.Limit = AppDefaultPaging.Limit;

            var result = await new TaskAuditor<PagedResult<TKey, TModel>>(() => Repository.GetAllAsync(filterModel), Logger, this).StartAsync();

            return Ok(result);
        }

        [HttpPut("{id}")]
        [CheckModelForNull]
        [ValidateModelState]
        public virtual async Task<IActionResult> Put([FromRoute] TKey id, [FromBody] TModel model)
        {
            var result = await new TaskAuditor<ICrudResult<TKey, TModel>>(() => Repository.UpdateAsync(id, model), Logger, this).StartAsync();

            return WebUtils.CreateActionResult(result);
        }

        [HttpPost]
        [CheckModelForNull]
        [ValidateModelState]
        public virtual async Task<IActionResult> Post([FromBody] TModel model)
        {
            var result = await new TaskAuditor<ICrudResult<TKey, TModel>>(() => Repository.CreateAsync(model), Logger, this).StartAsync();

            return WebUtils.CreateActionResult(result);
        }

        [HttpDelete]
        [ValidateModelState]
        public virtual async Task<IActionResult> Delete([FromRoute] TKey id)
        {
            var result = await new TaskAuditor<ICrudResult<TKey, TModel>>(() => Repository.DeleteAsync(id), Logger, this).StartAsync();

            return WebUtils.CreateActionResult(result);
        }
    }

    /// <summary>
    /// Logs function time usage.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TaskAuditor<T>
    {
        private readonly Func<Task<T>> _func;
        private Stopwatch _sw = new Stopwatch();
        private readonly ILogger _logger;
        private readonly Controller _ctrl;

        public TaskAuditor(Func<Task<T>> func, ILogger logger, Controller ctrl)
        {
            _func = func;
            _logger = logger;
            _ctrl = ctrl;
        }

        public async Task<T> StartAsync()
        {
            _sw.Start();
            try
            {
                return await _func();
            }
            finally
            {
                _sw.Stop();

                _logger.LogInformation($"REST API -- {this._sw} -- {_ctrl.Request.Method} -- {_ctrl.Url} -- {_ctrl.Request.HttpContext.Connection.RemoteIpAddress}");
            }
        }
    }

}
