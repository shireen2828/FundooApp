// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Shireen kk"/>
//---------------------------------------------------------------------------------------

namespace FundooApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FundooManager.Interfaces;
    using FundooModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// collaborator controller class
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CollaboratorController : ControllerBase
    {
        /// <summary>
        /// private method for ICollaboratorManager
        /// </summary>
        private readonly ICollaboratorManager collaboratorManager;
        /// <summary>
        /// constructor for collaborator manager
        /// </summary>
        /// <param name="collaboratorManager"></collaboratorManager>
        public CollaboratorController(ICollaboratorManager collaboratorManager)
        {
            this.collaboratorManager = collaboratorManager;
        }

        /// <summary>
        /// Add collaborators request
        /// </summary>
        /// <param name="model"></model>
        /// <returns></addCollaborators>
        [HttpPost]
        [Route("addCollaborators")]
        public IActionResult AddCollaborators([FromBody] CollaboratorModel model)
        {
            try
            {
                bool result = this.collaboratorManager.AddCollaborator(model);
                if (result.Equals(true))
                {
                    return this.Ok(new ResponseModel<CollaboratorModel>() { Status = true, Message = "New Collaborator Added Sucessfully", Data = model });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Add Collaborator" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Delete collaborator request
        /// </summary>
        /// <param name="collaboratorId"></collaboratorId>
        /// <returns></collaboratorId>
        [HttpDelete]
        [Route("collaboratorId")]
        public IActionResult DeleteCollaborator(int collaboratorId)
        {
            try
            {
                var result = this.collaboratorManager.DeleteCollaborator(collaboratorId);
                if (result.Equals(true))
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Message = "Collaborator Deleted Sucessfully", Data = collaboratorId });
                }

                return this.BadRequest(new { Status = false, Message = "Unable to delete collaborator : Enter valid Id" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Retrieve all collaborator request
        /// </summary>
        /// <param name="userId"></userId>
        /// <returns></getCollaborator>
        [HttpGet]
        [Route("getCollaborator")]
        public IActionResult RetrieveAllCollaborator(int noteId)
        {
            try
            {
                IEnumerable<CollaboratorModel> result = this.collaboratorManager.GetCollaborator(noteId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<IEnumerable<CollaboratorModel>>() { Status = true, Message = "Retrieve Collaborator Successfully", Data = result });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Retrieve Collaborator" });

            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
    }
}
