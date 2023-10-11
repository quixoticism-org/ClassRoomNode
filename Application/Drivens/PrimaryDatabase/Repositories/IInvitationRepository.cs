﻿using Application.Domain.Entities;
using Application.Domain.ValueObjects;

namespace Application.Drivens.PrimaryDatabase.Repositories;

public interface IInvitationRepository : IBaseRepository<Invitation, InvitationId>
{
    
}