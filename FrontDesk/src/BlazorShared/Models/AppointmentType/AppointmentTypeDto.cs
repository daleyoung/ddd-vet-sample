﻿using System;

namespace BlazorShared.Models.AppointmentType
{
    public class AppointmentTypeDto
    {
        public string AppointmentTypeId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Duration { get; set; }
    }
}
