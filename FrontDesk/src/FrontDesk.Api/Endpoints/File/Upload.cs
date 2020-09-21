﻿using Ardalis.ApiEndpoints;
using BlazorShared.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FrontDesk.Api.FileEndpoints
{
    public class Upload : BaseAsyncEndpoint<FileItem, bool>
    {
        public Upload()
        {
        }

        [HttpPost("api/files")]
        [SwaggerOperation(
            Summary = "Uploads a file",
            Description = "Uploads a file",
            OperationId = "files.upload",
            Tags = new[] { "FileEndpoints" })
        ]
        public override async Task<ActionResult<bool>> HandleAsync(FileItem request, CancellationToken cancellationToken)
        {
            if (request == null || string.IsNullOrEmpty(request.DataBase64)) return BadRequest();

            var fileData = Convert.FromBase64String(request.DataBase64);
            if (fileData.Length <= 0) return BadRequest();

            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), @"images/Patients", request.FileName);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            System.IO.File.WriteAllBytes(fullPath, fileData);

            return Ok(true);
        }
    }
}
