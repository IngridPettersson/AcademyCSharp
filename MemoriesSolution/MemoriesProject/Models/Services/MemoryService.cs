using MemoriesProject.Models.Entities;
using MemoriesProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoriesProject.Models.Services
{
    public class MemoryService
    {
        MyContext context;

        public MemoryService(MyContext context)
        {
            this.context = context;
        }
        public MemoryIndexVM[] GetAllMemories()
        {
           return context
                .Memories
                .Select(o => new MemoryIndexVM
                {
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
            context.Memories
                .Add(new Memory
                {
                    MemoryHolder = viewModel.MemoryHolder,
                    PeopleInMemory = viewModel.PeopleInMemory,
                    MemoryTitle = viewModel.MemoryTitle,
                    //When = viewModel.When,
                    WhenInWords = viewModel.WhenInWords,
                    Description = viewModel.Description,
                    ImageUrl = viewModel.ImageUrl,
                    //AddedWhen = viewModel.AddedWhen
                });
            context.SaveChanges();
            
        }
    }
}
