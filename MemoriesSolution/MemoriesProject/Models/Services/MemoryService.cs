using MemoriesProject.Models.Entities;
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
                     Description = o.Description,
                     HasImage = (bool)o.HasImage,
                     AddedWhen = o.AddedWhen
                 }
                )
                 .ToArray();
        }

        internal void EditMemory(MemoryEditVM viewModel, int id)
        {
            
            //if (viewModel.ImageToUpload != null)
            //{
            //    var filePath = Path.Combine(webHostEnv.WebRootPath, "Uploads", viewModel.ImageToUpload.FileName);
            //    using (var fileStream = new FileStream(filePath, FileMode.Create))
            //    {
            //        viewModel.ImageToUpload.CopyTo(fileStream);
            //    }

            //}

            var memoryToUpdate = context.Memories
                .Find(id);

            memoryToUpdate.MemoryHolder = viewModel.MemoryHolder;
            memoryToUpdate.PeopleInMemory = viewModel.PeopleInMemory;
            memoryToUpdate.MemoryTitle = viewModel.MemoryTitle;
            memoryToUpdate.WhenInWords = viewModel.WhenInWords;
            memoryToUpdate.Description = viewModel.Description;
            //memoryToUpdate.ImagePath = viewModel.ImageToUpload?.FileName;
            //memoryToUpdate.HasImage = viewModel.ImageToUpload?.FileName.Length > 0;

            context.SaveChanges();
        }

        internal MemoryDeleteVM GetDeleteVM(Memory memory)
        {
            return new MemoryDeleteVM
            {
                MemoryHolder = memory.MemoryHolder,
                PeopleInMemory = memory.PeopleInMemory,
                MemoryTitle = memory.MemoryTitle
            };
        }

        internal void DeleteMemory(MemoryDeleteVM memoryDeleteVM, int id)
        {
            var memoryToRemove = context.Memories
                .Find(id);

            context.Memories
                .Remove(memoryToRemove);

            context.SaveChanges();
        }

        internal Task AddMemoryAsync(MemoryCreateVM viewModel)
        {
            if (viewModel.ImageToUpload != null)
            {
                var filePath = Path.Combine(webHostEnv.WebRootPath, "Uploads", viewModel.ImageToUpload.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    viewModel.ImageToUpload.CopyTo(fileStream);
                }
            }


            context.Memories
                .Add(new Memory
                {
                    MemoryHolder = viewModel.MemoryHolder,
                    PeopleInMemory = viewModel.PeopleInMemory,
                    MemoryTitle = viewModel.MemoryTitle,
                    //When = viewModel.When,
                    WhenInWords = viewModel.WhenInWords,
                    Description = viewModel.Description,
                    ImagePath = viewModel.ImageToUpload?.FileName, //<img src=/Uploads/@Model.ImagePath>
                    HasImage = viewModel.ImageToUpload?.FileName.Length > 0,
                    AddedWhen = DateTime.Now
                    //AddedWhen = new DateTime(DateTime.Now.ToShortDateString())
                });
            context.SaveChanges();
            return Task.CompletedTask;
        }

        internal void AddMemory(MemoryCreateVM viewModel)
        {
            if (viewModel.ImageToUpload != null)
            {
                var filePath = Path.Combine(webHostEnv.WebRootPath, "Uploads", viewModel.ImageToUpload.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    viewModel.ImageToUpload.CopyTo(fileStream);
                }
            }


            context.Memories
                .Add(new Memory
                {
                    MemoryHolder = viewModel.MemoryHolder,
                    PeopleInMemory = viewModel.PeopleInMemory,
                    MemoryTitle = viewModel.MemoryTitle,
                    //When = viewModel.When,
                    WhenInWords = viewModel.WhenInWords,
                    Description = viewModel.Description,
                    ImagePath = viewModel.ImageToUpload?.FileName, //<img src=/Uploads/@Model.ImagePath>
                    HasImage = viewModel.ImageToUpload?.FileName.Length > 0,
                    AddedWhen = DateTime.Now
                    //AddedWhen = new DateTime(DateTime.Now.ToShortDateString())
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
