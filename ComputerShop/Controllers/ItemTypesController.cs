﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComputerShop.Models;

namespace ComputerShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemTypesController : ControllerBase
    {
        private readonly ComputerContext _context;

        public ItemTypesController(ComputerContext context)
        {
            _context = context;
        }

        // GET: api/ItemTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemType>>> GetitemTypes()
        {
            return await _context.itemTypes.ToListAsync();
        }

        // GET: api/ItemTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemType>> GetItemType(int id)
        {
            var itemType = await _context.itemTypes.FindAsync(id);

            if (itemType == null)
            {
                return NotFound();
            }

            return itemType;
        }

        // PUT: api/ItemTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemType(int id, ItemType itemType)
        {
            if (id != itemType.ItemTypeId)
            {
                return BadRequest();
            }

            _context.Entry(itemType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ItemTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemType>> PostItemType(ItemType itemType)
        {
            _context.itemTypes.Add(itemType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemType", new { id = itemType.ItemTypeId }, itemType);
        }

        // DELETE: api/ItemTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemType(int id)
        {
            var itemType = await _context.itemTypes.FindAsync(id);
            if (itemType == null)
            {
                return NotFound();
            }

            _context.itemTypes.Remove(itemType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemTypeExists(int id)
        {
            return _context.itemTypes.Any(e => e.ItemTypeId == id);
        }
    }
}
