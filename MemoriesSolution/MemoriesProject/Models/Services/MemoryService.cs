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
                    When = (DateTime)o.When,
                    WhenInWords = o.WhenInWords,
                    Description = o.Description
                }
               )
                .ToArray();
        }

        internal void AddMemory()
        {
            throw new NotImplementedException();
        }
    }
}
