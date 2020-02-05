using Marvel.Api.Domain.Models.Entities;
using Marvel.Domain.Containers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Marvel.Controllers
{
    public class BaseApiController<T> : ControllerBase
        where T : class, new()
    {
        public DataWrapper<T> CreateWrapper(HttpStatusCode code, IEnumerable<T> list)
            //where T : class, new()
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

        public string GetStatusReason(HttpStatusCode statusCode)
        {
            return Regex.Replace(statusCode.ToString(), "(\\B[A-Z])", " $1");
        }

        public ActionResult<DataWrapper<T>> GetResult(IEnumerable<T> listOfItems) 
        {
            if (listOfItems.Any())
            {
                var wrapper = CreateWrapper(HttpStatusCode.OK, listOfItems);
                return Ok(wrapper);
            }

            return StatusCode((int)HttpStatusCode.NotFound, "We couldn't find that item.");
        }

        public ActionResult<DataWrapper<T>> GetResult(T item)
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
