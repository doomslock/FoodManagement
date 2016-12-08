using AutoMapper;
using FoodManagement.Core.Model;
using System;

namespace FoodManagement.Core
{
    public class FamilyService : IFamilyService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public FamilyService(IUnitOfWork uow, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = uow;
        }
        public bool PersonIsAuthorizedToFamily(Guid personId, Guid familyId)
        {
            Person p = _unitOfWork.Repository<Person>().SelectById(personId);
            return p.FamilyId == familyId;
        }
    }
}
