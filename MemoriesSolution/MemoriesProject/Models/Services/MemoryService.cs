﻿using MemoriesProject.Models.Entities;
using MemoriesProject.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MemoriesProject.Models.Services
{
    public class MemoryService
    {
        MyContext context;
        IWebHostEnvironment webHostEnv;

        public MemoryService(MyContext context, IWebHostEnvironment webHostEnv)
        {
            this.context = context;
            this.webHostEnv = webHostEnv;
        }
        public MemoryIndexVM[] GetAllMemories()
        {
           return context
                .Memories
                .Select(o => new MemoryIndexVM
                {
                    Id = o.Id,
                    MemoryHolder = o.MemoryHolder,
                    PeopleInMemory = o.PeopleInMemory,
                    MemoryTitle = o.MemoryTitle,
                    WhenInWords = o.WhenInWords,
                    Description = o.Description
                }
               )
                .ToArray();
        }

        internal void AddMemory(MemoryCreateVM viewModel)
        {
            var filePath = Path.Combine(webHostEnv.WebRootPath, "Uploads", viewModel.ImageToUpload.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                viewModel.ImageToUpload.CopyTo(fileStream);
            }

     
            context.Memories
                .Add(new Memory
                {
                    //Id = viewModel
                    MemoryHolder = viewModel.MemoryHolder,
                    PeopleInMemory = viewModel.PeopleInMemory,
                    MemoryTitle = viewModel.MemoryTitle,
                    //When = viewModel.When,
                    WhenInWords = viewModel.WhenInWords,
                    Description = viewModel.Description,
                    ImagePath = viewModel.ImageToUpload.FileName, //<img src=/Uploads/@Model.ImagePath>
                    HasImage = viewModel.ImageToUpload.FileName.Length > 0
                    //AddedWhen = viewModel.AddedWhen
                });
            context.SaveChanges();

            //// Note: IWebHostEnvironment was injected into the controller
            //var filePath = Path.Combine(webHostEnvironment.WebRootPath,
            //    "Uploads", viewModel.Image.);

            //// Save file to disk
            //using (var fileStream = new FileStream(filePath, FileMode.Create))
            //{
            //    viewModel.Image.CopyTo(fileStream);
            //}


        }

        internal MemoryEditVM GetMemoryEditVM(Memory memory)
        {
            return new MemoryEditVM
            {
                MemoryHolder = memory.MemoryHolder,
                PeopleInMemory = memory.PeopleInMemory,
                MemoryTitle = memory.MemoryTitle,
                WhenInWords = memory.WhenInWords,
                Description = memory.Description,
                //ImageToUpload.FileName = ImagePath
            };
        }

        internal Memory GetMemoryById(int id)
        {
            return context.Memories
                .Find(id);
        }

        internal MemoryDetailsVM GetMemoryDetailsVM(Memory memory)
        {
            return new MemoryDetailsVM
            {
                MemoryTitle = memory.MemoryTitle,
                MemoryHolder = memory.MemoryHolder,
                PeopleInMemory = memory.PeopleInMemory,
                WhenInWords = memory.WhenInWords,
                Description = memory.Description,
                ImagePath = memory.ImagePath
            };
        }

    }
}
