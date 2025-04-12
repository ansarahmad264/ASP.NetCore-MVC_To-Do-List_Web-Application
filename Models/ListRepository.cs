﻿using Microsoft.EntityFrameworkCore;

namespace To_Do_List.Models
{
    public class ListRepository : IListRepository
    {
        private readonly ToDoListDbConext _toDoListDbContext;
        public ListRepository(ToDoListDbConext toDoListDbContext)
        {
            _toDoListDbContext = toDoListDbContext;
        }

        public bool CreateList(List list)
        {
            list.Creation_Date = DateOnly.FromDateTime(DateTime.Today);

           bool userExist = _toDoListDbContext.Users.Any(u =>  u.Id == list.UserId);

           if (!userExist)
            {
                return false;
            }

            _toDoListDbContext.Lists.Add(list);
            _toDoListDbContext.SaveChanges();
            return true;            
        }

        public IEnumerable<List> GetAllList(int id)
        {
           
           return _toDoListDbContext.Lists.Where(l => l.UserId == id)
                .OrderByDescending(l => l.Creation_Date).ToList();
        }

        
    }
        
}
