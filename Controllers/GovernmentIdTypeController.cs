using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VisitorManagement.Data;
using VisitorManagement.DataModels;

[Route("api/[controller]")]
[ApiController]
public class GovernmentIdTypeController : ControllerBase
{
    private readonly VisitorManagementDbContext _context;

    public GovernmentIdTypeController(VisitorManagementDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GovernmentIdType>>> GetAll()
    {
        return await _context.GovernmentIdTypes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GovernmentIdType>> Get(int id)
    {
        var item = await _context.GovernmentIdTypes.FindAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<GovernmentIdType>> Add(GovernmentIdType governmentIdType)
    {
        _context.GovernmentIdTypes.Add(governmentIdType);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = governmentIdType.Id }, governmentIdType);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, GovernmentIdType governmentIdType)
    {
        if (id != governmentIdType.Id)
            return BadRequest();

        _context.Entry(governmentIdType).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _context.GovernmentIdTypes.FindAsync(id);
        if (item == null)
            return NotFound();

        _context.GovernmentIdTypes.Remove(item);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
