﻿// <auto-generated />
namespace Contracts
{
    using System;
    using System.Collections.Generic;

    using Entities.Models;

    public interface IAccountRepository
    {
        IEnumerable<Account> AccountsByOwner(Guid ownerId);
    }
}