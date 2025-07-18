﻿using HIVMedicalSystem.Domain.Abstractions.Entities;

namespace HIVMedicalSystem.Domain.Entities;

public class Role: Entity<int>
{
    public string RoleName { get; set; }
    public virtual ICollection<User> Users { get; set; }
}