﻿using CaveProvider.API.Domain.Classes.Common;
using CaveProvider.Core.Model.Institution;
using CaveProvider.Domain.Interface;
using CaveProvider.Domain.Interface.Common;
using CaveProvider.Repository.Interface;


namespace CaveProvider.Domain
{
    public class InstitutionDomain: DataDomain<Institution>, IInstitutionDomain
    {
        public InstitutionDomain(IInstitutionRepository respository):base(respository) { }
    }
}
