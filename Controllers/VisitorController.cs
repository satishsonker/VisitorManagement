using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VisitorManagement.Data;
using VisitorManagement.DataModels;
using VisitorManagement.DTO.Response;

[Route("api/[controller]")]
[ApiController]
public class VisitorController : ControllerBase
{
    private readonly VisitorManagementDbContext _context;

    public VisitorController(VisitorManagementDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<PagingResponse<Visitor>>> GetAll([FromQuery]int pageNo=1, [FromQuery] int pageSize=20)
    {
        var resp=new PagingResponse<Visitor>();
        var query = _context.Visitors
            .Include(v => v.GovernmentIdType)
            .Where(x => !x.IsDeleted).AsQueryable();
        resp.Data= await query
            .Skip((pageNo - 1) * pageSize)
            .Take(pageSize)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
        resp.TotalRecords= await query.CountAsync();
        resp.PageNo = pageNo;
        resp.PageSize = pageSize;

        return resp;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Visitor>> Get(int id)
    {
        var visitor = await _context.Visitors.Include(v => v.GovernmentIdType)
                                             .FirstOrDefaultAsync(v => v.Id == id);
        return visitor == null ? NotFound() : Ok(visitor);
    }

    [HttpPost]
    public async Task<ActionResult<Visitor>> Add(Visitor visitor)
    {
        _context.Visitors.Add(visitor);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = visitor.Id }, visitor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Visitor visitor)
    {
        if (id != visitor.Id)
            return BadRequest();

        _context.Entry(visitor).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var visitor = await _context.Visitors.FindAsync(id);
        if (visitor == null)
            return NotFound();

        _context.Visitors.Remove(visitor);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<Visitor>>> Search([FromQuery]string? searchTerm, [FromQuery] int pageNo = 1, [FromQuery] int pageSize = 20)
    {
        var query = _context.Visitors.AsQueryable();

        if (!string.IsNullOrEmpty(searchTerm))
        {
            query = query.Where(v => v.FirstName.Contains(searchTerm));
            query = query.Where(v => v.LastName.Contains(searchTerm));
            query = query.Where(v => v.ContactNo.Contains(searchTerm));
            query = query.Where(v => v.Address.Contains(searchTerm));
        }

        return await query.Include(v => v.GovernmentIdType)
             .Where(x => !x.IsDeleted)
            .Skip((pageNo - 1) * pageSize)
            .Take(pageSize)
            .OrderByDescending(x => x.CreatedAt).ToListAsync();
    }

    [HttpGet("search/contact/{contactNo}")]
    public async Task<ActionResult<List<Visitor>>> SearchByContact(string contactNo)
    {
        var visitor = await _context.Visitors.Where(v => v.ContactNo == contactNo).ToListAsync();
        return visitor.Count == 0 ? NotFound() : Ok(visitor);
    }
}
