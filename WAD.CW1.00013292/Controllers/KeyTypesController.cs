using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD.CW1._00013292.DAL.Dtos;
using WAD.CW1._00013292.DAL.Interfaces;
using WAD.CW1._00013292.Models;

namespace WAD.CW1._00013292.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyTypesController : ControllerBase
    {
        private readonly IKeyTypeRepository _keyTypeRepository;
        private readonly IMapper _mapper;

        public KeyTypesController(IKeyTypeRepository keyTypeRepository, IMapper mapper)
        {
            _keyTypeRepository = keyTypeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllKeyTypes()
        {
            var keyTypes = await _keyTypeRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<KeyTypeDto>>(keyTypes));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetKeyType(int id)
        {
            var keyType = await _keyTypeRepository.GetByIdAsync(id);
            if (keyType == null)
            {
                return NotFound($"KeyType with ID {id} not found");
            }
            return Ok(_mapper.Map<KeyTypeDto>(keyType));
        }

        [HttpPost]
        public async Task<IActionResult> CreateKeyType(KeyTypeDto keyTypeDto)
        {
            var keyType = _mapper.Map<KeyType>(keyTypeDto);
            var createdKeyType = await _keyTypeRepository.AddAsync(keyType);
            return Ok($"Created KeyType with ID {createdKeyType.KeyTypeId}");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKeyType(int id, KeyTypeDto keyTypeDto)
        {
            if (id != keyTypeDto.KeyTypeId)
            {
                return BadRequest("ID mismatch");
            }

            var keyTypeToUpdate = await _keyTypeRepository.GetByIdAsync(id);
            if (keyTypeToUpdate == null)
            {
                return NotFound($"KeyType with ID {id} not found");
            }

            _mapper.Map(keyTypeDto, keyTypeToUpdate);
            await _keyTypeRepository.UpdateAsync(keyTypeToUpdate);

            return Ok($"Updated KeyType with ID {id}");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKeyType(int id)
        {
            var keyType = await _keyTypeRepository.GetByIdAsync(id);
            if (keyType == null)
            {
                return NotFound($"KeyType with ID {id} not found");
            }

            await _keyTypeRepository.DeleteAsync(id);
            return Ok($"Deleted KeyType with ID {id}");
        }
    }
}
