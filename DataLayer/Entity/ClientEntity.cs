﻿using DataLayer.Interfaces;

namespace DataLayer.Entity
{
    public class ClientEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Passport { get; set; }

        public ClientEntity(int id, string name, string passport)
        {
            Id = id;
            Name = name;
            Passport = passport;
        }
    }
}
