﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IEventRepository
    {
        public List<Event> GetAllEvents();
        public List<Event> GetAllCurrentEvents();
        public Event GetEventById(int id);
        public Event CreateEvent(string title, string description, User author, DateTime publishDate, DateTime startDate, DateTime endDate);
        public void UpdateEvent(int id, string title, string description, DateTime startDate, DateTime endDate);
        public void DeleteEvent(int id);
    }
}
    