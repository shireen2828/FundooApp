// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Shireen kk"/>
//--------------------------------------------------------------------------------------

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
    /// Label controller class
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LabelController : ControllerBase
    {
        /// <summary>
        /// private readonly method
        /// </summary>
        private readonly ILabelManager LabelManager;

        /// <summary>
        /// constructor for label controller
        /// </summary>
        /// <param name="LabelManager"></LabelManager>
        public LabelController(ILabelManager LabelManager)
        {
            this.LabelManager = LabelManager;
        }

        /// <summary>
        /// request for add label
        /// </summary>
        /// <param name="model"></model>
        /// <returns></addLabel>
        [HttpPost]
        [Route("addLabel")]
        public IActionResult AddLabel([FromBody] LabelModel model)
        {
            try
            {
                bool result = this.LabelManager.AddLabel(model);
                if (result.Equals(true))
                {
                    return this.Ok(new ResponseModel<LabelModel>() { Status = true, Message = "New Label Added Sucessfully", Data = model });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Add Label" });

            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// request for update label
        /// </summary>
        /// <param name="model"></model>
        /// <returns></LabelController.cs>
        [HttpPut]
        [Route("updateLabel")]
        public IActionResult UpdateLabel([FromBody] LabelModel model)
        {
            try
            {
                var result = this.LabelManager.UpdateLabel(model);
                if (result.Equals("UPDATE SUCCESSFULL"))
                {
                    return this.Ok(new ResponseModel<LabelModel>() { Status = true, Message = result, Data = model });
                }

                return this.BadRequest(new { Status = false, Message = "Error while updating Label" });

            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// request for remove label
        /// </summary>
        /// <param name="labelId"></labelId>
        /// <returns></LabelController.cs>
        [HttpGet]
        [Route("RemoveLabel")]
        public IActionResult RemoveLabel(int labelId)
        {
            try
            {
                bool result = this.LabelManager.RemoveLabel(labelId);
                if (result.Equals(true))
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Message = "Removed Label Successfully" });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Remove Label" });

            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// request for get label
        /// </summary>
        /// <param name="noteId"></noteId>
        /// <returns></LabelController.cs>
        [HttpGet]
        [Route("getlabel")]
        public IActionResult GetLabel(int noteId)
        {
            try
            {
                IEnumerable<LabelModel> result = this.LabelManager.GetLabel(noteId);
                if (result.Count() > 0)
                {
                    return this.Ok(new ResponseModel<IEnumerable<LabelModel>>() { Status = true, Message = "Label", Data = result });
                }

                return this.BadRequest(new { Status = false, Message = "Failed" });

            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// request for get label
        /// </summary>
        /// <param name="userId"></userId>
        /// <returns></LabelController.cs>
        [HttpGet]
        [Route("Getlabel{userId}")]
        public IActionResult GetLabelbyId(int userId)
        {
            try
            {
                LabelModel result = this.LabelManager.GetLabelbyId(userId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<LabelModel>() { Status = true, Message = "get Label Successfully", Data = result });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Get Label" });

            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
    }
}
