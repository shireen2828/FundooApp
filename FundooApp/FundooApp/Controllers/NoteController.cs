// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NoteController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Shireen kk"/>
//---------------------------------------------------------------------------------------

namespace FundooApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using FundooManager.Interfaces;
    using FundooManager.Manager;
    using FundooModel;
    using FundooModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
   
    /// <summary>
    /// note controller class
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        /// <summary>
        /// private method for INote manager
        /// </summary>
        private readonly INoteManager manager;

        /// <summary>
        /// constructor for note controller
        /// </summary>
        /// <param name="manager"></manager>
        public NoteController(INoteManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// request for add notes
        /// </summary>
        /// <param name="model"></model>
        /// <returns></returns>
        [HttpPost]
        [Route("addNotes")]
        public ActionResult AddNotes([FromBody] NotesModel model)
        {
            try
            {
                bool result = this.manager.AddNotes(model);

                if (result.Equals(true))
                {
                    return this.Ok(new ResponseModel<NotesModel>() { Status = true, Message = "Notes Added Successfully", Data = model });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Add Notes" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// request for retrieve notes
        /// </summary>
        /// <param name="noteId"></noteId>
        /// <returns></returns>
        [HttpGet]
        [Route("RetrieveNotes{noteId}")]
        public IActionResult RetrieveNotesById(int noteId)
        {
            try
            {
                NotesModel result = this.manager.RetrieveNotesById(noteId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<NotesModel>() { Status = true, Message = "Retrieve Notes By Id Successfully", Data = result });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Retrieve Notes By id" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// request for Delete notes
        /// </summary>
        /// <param name="noteId"></noteId>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteNote{noteId}")]
        public IActionResult DeleteNotes(int noteId)
        {
            try
            {
                var result = this.manager.RemoveNote(noteId);
                if (result.Equals(true))
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Message = "Delete Note Successfully", Data = noteId });
                }

                return this.BadRequest(new { Status = false, Message = "Unable to delete note : Enter valid Id" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// request for update notes
        /// </summary>
        /// <param name="model"></model>
        /// <returns></returns>
        [HttpPut]
        [Route("updateNotes")]
        public IActionResult UpdateNotes([FromBody] NotesModel model)
        {
            try
            {
                var result = this.manager.UpdateNotes(model);
                if (result.Equals("UPDATE SUCCESSFULL"))
                {
                    return this.Ok(new ResponseModel<NotesModel>() { Status = true, Message = result, Data = model });
                }

                return this.BadRequest(new { Status = false, Message = "Error while updating notes" });          
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// request for pin
        /// </summary>
        /// <param name="noteId"></noteId>
        /// <returns></returns>
        [HttpPut]
        [Route("pin")]
        public IActionResult Pin(int noteId)
        {
            try
            {
                var result = this.manager.Pin(noteId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = result });
                }

                return this.BadRequest(new { Status = false, Message = result });            
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// request for unpin
        /// </summary>
        /// <param name="noteId"></noteId>
        /// <returns></returns>
        [HttpPut]
        [Route("Unpin")]
        public IActionResult Unpin(int noteId)
        {
            try
            {
                var result = this.manager.Unpin(noteId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = result });
                }

                return this.BadRequest(new { Status = false, Message = result });            
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// request for archieve or unarchieve
        /// </summary>
        /// <param name="noteId"></noteId>
        /// <returns></returns>
        [HttpPut]
        [Route("archiveOrUnarchive")]
        public IActionResult ArchieveOrUnarchieve(int noteId)
        {
            try
            {
                var result = this.manager.ArchieveOrUnarchieve(noteId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = result });
                }

                return this.BadRequest(new { Status = false, Message = result });            
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// request for trash or untrash
        /// </summary>
        /// <param name="noteId"></noteId>
        /// <returns></returns>
        [HttpPut]
        [Route("trashorUntrash")]
        public IActionResult TrashorUntrash(int noteId)
        {
            try
            {
                var result = this.manager.TrashorUntrash(noteId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = result });
                }

                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// request for color
        /// </summary>
        /// <param name="noteId"></noteId>
        /// <param name="color"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("color")]
        public IActionResult Color(int noteId, string color)
        {
            try
            {
                bool result = this.manager.Color(color, noteId);

                if (result.Equals(true))
                {
                    return this.Ok(new ResponseModel<NotesModel>() { Status = true, Message = "Notes is Coloured" });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Color" });            
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// request for add reminder
        /// </summary>
        /// <param name="noteId"></noteId>
        /// <param name="reminder"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("AddReminder")]
        public IActionResult AddReminder(int noteId, string reminder)
        {
            try
            {
                var result = this.manager.AddReminder(noteId, reminder);
                if (result.Equals(true))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Reminder Set Successfully", Data = reminder });
                }

                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// request for get reminder
        /// </summary>
        /// <returns></reminder>
        [HttpGet]
        [Route("getReminder")]
        public IActionResult GetReminder()
        {
            try
            {
                IEnumerable<NotesModel> result = this.manager.GetReminder();
                if (result != null)
                {
                    return this.Ok(new ResponseModel<IEnumerable<NotesModel>>() { Status = true, Message = "Retrieve All Notes Whose Reminder Is Set", Data = result });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Retrieve Notes" });     
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// request for get note
        /// </summary>
        /// <param name="userId"></userId>
        /// <returns></returns>
        [HttpGet]
        [Route("getNote")]
        public IActionResult GetNote(int userId)
        {
            try
            {
                IEnumerable<NotesModel> result = this.manager.GetNote(userId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<IEnumerable<NotesModel>>() { Status = true, Message = "Get Note Successfully", Data = result });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Get Note" });            
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// request for upload image 
        /// </summary>
        /// <param name="noteId"></noteId>
        /// <param name="image"></image>
        /// <returns></returns>
        [HttpPut]
        [Route("uploadImage")]
        public IActionResult UploadImage(int noteId, IFormFile image)
        {
            try
            {
                bool result = this.manager.UploadImage(noteId, image);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Message = "Image uploaded successfully" });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Retrieve Notes" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
    }
}
