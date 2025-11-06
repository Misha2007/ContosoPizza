using ContosoPizza.Data;
using ContosoPizza.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{

    private readonly ContosoPizzaContext _context;

    public PizzaController(ContosoPizzaContext context)
    {
        _context = context;
    }

    // GET all action
    [HttpGet]
    public async Task<ActionResult<List<Pizza>>> GetAll()
    {
        return await _context.Pizzas.ToListAsync();

    }

    // GET by Id action
    [HttpGet("{id}")]
    public async Task<ActionResult<Pizza>> Get(int id)
    {
        var pizza = await _context.Pizzas.FindAsync(id);

            if (pizza == null)
            {
                return NotFound();
            }

            return pizza;

    }

    // POST action
    [HttpPost]
    public async Task<IActionResult> Create(Pizza pizza)
    {
        _context.Pizzas.Add(pizza);
        await _context.SaveChangesAsync();  
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    // PUT action
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Pizza pizza)
    {
        if (id != pizza.Id)
            {
                return BadRequest();
            }

            _context.Entry(pizza).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PizzaExists(id))
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

    // DELETE action
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var pizza = await _context.Pizzas.FindAsync(id);
        if (pizza == null)
        {
            return NotFound();
        }

        _context.Pizzas.Remove(pizza);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PizzaExists(int id)
        {
            return _context.Pizzas.Any(e => e.Id == id);
        }


}