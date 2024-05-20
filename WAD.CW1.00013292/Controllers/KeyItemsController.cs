using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD.CW1._00013292.DAL.Dtos;
using WAD.CW1._00013292.DAL.Interfaces;
using WAD.CW1._00013292.Models;

namespace WAD.CW1._00013292.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyItemsController : ControllerBase
    {
        private readonly IKeyItemRepository _keyItemRepository;
        private readonly IMapper _mapper;

        public KeyItemsController(IKeyItemRepository keyItemRepository, IMapper mapper)
        {
            _keyItemRepository = keyItemRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllKeyItems()
        {
            var keyItems = await _keyItemRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<KeyItemDto>>(keyItems));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetKeyItem(int id)
        {
            var keyItem = await _keyItemRepository.GetByIdAsync(id);
            if (keyItem == null)
            {
                return NotFound($"KeyItem with ID {id} not found");
            }
            return Ok(_mapper.Map<KeyItemDto>(keyItem));
        }

        [HttpPost]
        public async Task<IActionResult> CreateKeyItem(KeyItemDto keyItemDto)
        {
            var keyItem = _mapper.Map<KeyItem>(keyItemDto);
            var createdKeyItem = await _keyItemRepository.AddAsync(keyItem);
            return Ok($"Created KeyItem with ID {createdKeyItem.KeyItemId}");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKeyItem(int id, KeyItemDto keyItemDto)
        {
            if (id != keyItemDto.KeyItemId)
            {
                return BadRequest("ID mismatch");
            }

            var keyItemToUpdate = await _keyItemRepository.GetByIdAsync(id);
            if (keyItemToUpdate == null)
            {
                return NotFound($"KeyItem with ID {id} not found");
            }

            _mapper.Map(keyItemDto, keyItemToUpdate);
            await _keyItemRepository.UpdateAsync(keyItemToUpdate);

            return Ok($"Updated KeyItem with ID {id}");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKeyItem(int id)
        {
            var keyItem = await _keyItemRepository.GetByIdAsync(id);
            if (keyItem == null)
            {
                return NotFound($"KeyItem with ID {id} not found");
            }

            await _keyItemRepository.DeleteAsync(id);
            return Ok($"Deleted KeyItem with ID {id}");
        }
    }
}
