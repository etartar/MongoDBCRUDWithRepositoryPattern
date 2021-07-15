using Microsoft.AspNetCore.Mvc;
using MongoDBCRUDWithRepositoryPattern.Constants;
using MongoDBCRUDWithRepositoryPattern.Models;
using MongoDBCRUDWithRepositoryPattern.Results;
using MongoDBCRUDWithRepositoryPattern.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDBCRUDWithRepositoryPattern.Controllers
{
    public abstract class BaseMongoController<T> : ControllerBase where T : MongoBaseModel
    {
        protected BaseMongoRepository<T> _baseMongoRepository;

        public BaseMongoController(BaseMongoRepository<T> baseMongoRepository)
        {
            _baseMongoRepository = baseMongoRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetModelList()
        {
            try
            {
                var data = await _baseMongoRepository.GetAllAsync();
                return Ok(new SuccessDataResult<List<T>>(Messages.GetModelListSuccessMessage, data));
            }
            catch(Exception ex)
            {
                return BadRequest(new ErrorDataResult<List<T>>(string.Format(Messages.GetModelListErrorMessage, ex.Message)));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetModel(string id)
        {
            try
            {
                var data = await _baseMongoRepository.GetByIdAsync(id);
                return Ok(new SuccessDataResult<T>(Messages.GetModelSuccessMessage, data));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorDataResult<T>(string.Format(Messages.GetModelErrorMessage, ex.Message)));
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateModel(T model)
        {
            try
            {
                await _baseMongoRepository.CreateAsync(model);
                return Ok(new SuccessResult(Messages.CreateModelSuccessMessage));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResult(string.Format(Messages.CreateModelErrorMessage, ex.Message)));
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateModel(string id, T model)
        {
            try
            {
                await _baseMongoRepository.UpdateAsync(id, model);
                return Ok(new SuccessResult(Messages.UpdateModelSuccessMessage));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResult(string.Format(Messages.UpdateModelErrorMessage, ex.Message)));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteModel(string id)
        {
            try
            {
                await _baseMongoRepository.DeleteAsync(id);
                return Ok(new SuccessResult(Messages.DeleteModelSuccessMessage));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResult(string.Format(Messages.DeleteModelErrorMessage, ex.Message)));
            }
        }
    }
}
