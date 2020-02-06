using Marvel.Api.Domain.Models.Entities;
using Marvel.Domain.Containers;
using Marvel.Domain.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Marvel.Controllers
{
    public abstract class BaseApiController<T> : ControllerBase
        where T : class, new()
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        private DataWrapper<T> CreateWrapper(HttpStatusCode code, IEnumerable<T> list)
        {
            return new DataWrapper<T>()
            {
                Code = ((int)code).ToString(),
                Status = GetStatusReason(code),
                Copyright = "© 2020 MARVEL",
                AttributionText = "Data provided by Marvel. © 2020 MARVEL",
                AttributionHtml = "<a href=\"http://marvel.com\">Data provided by Marvel. © 2020 MARVEL</a>",
                Etag = Guid.NewGuid().ToString(),
                Data = new DataContainer<T>()
                {
                    Results = list
                }
            };
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private string GetStatusReason(HttpStatusCode statusCode)
        {
            return statusCode == HttpStatusCode.OK? 
                statusCode.ToString(): Regex.Replace(statusCode.ToString(), "(\\B[A-Z])", " $1");
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        protected ActionResult<DataWrapper<T>> GetResult(IEnumerable<T> items)
        {
            if (items.Any())
            {
                var wrapper = CreateWrapper(HttpStatusCode.OK, items);
                return Ok(wrapper);
            }

            return StatusCode((int)HttpStatusCode.NotFound, "We couldn't find that item.");
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        protected ActionResult<DataWrapper<T>> GetResult(T item)
        {
            if (item != null)
            {
                var wrapper = CreateWrapper(HttpStatusCode.OK, new List<T>() { item });
                return Ok(wrapper);
            }

            return StatusCode((int)HttpStatusCode.NotFound, "We couldn't find that item.");
        }
    }
}
