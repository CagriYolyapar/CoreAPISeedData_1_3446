﻿using CoreAPISeedData_1.Models.Enums;

namespace CoreAPISeedData_1.Models.Entities
{
    public abstract class BaseEntity
    {

        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }
    }
}
