using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.Interface
{
    public interface ICollaboratorRepository
    {
        public bool AddCollaborator(CollaboratorModel model);
        public bool DeleteCollaborator(int collaboratorId);
        public IEnumerable<CollaboratorModel> GetCollaborator(int noteId);
    }
}

