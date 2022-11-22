using AuntyBCompere.Models.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuntyBCompere.Pages.Services
{
    public class DetailsModel : PageModel
    {
        private readonly AuntyBCompere.Data.AuntyBCompereContext _context;

        public DetailsModel(AuntyBCompere.Data.AuntyBCompereContext context)
        {
            _context = context;
        }

        private readonly List<Service> _services = new()
        {
            new()
            {
                Id = 1,
                Name  ="Event MC/Compere",
                FaIcon = "",
                Tagline = "YOUR CLASSY EVENT MC IS HERE WITH THE SWAG",
                Summary = "",
                Content = "Having to deal with people and creating an environment that fits the occasion can be a whole lot but NOT with <span class=\"fw-600\">Aunty B Compere.</span> She is a professional who has emceed all kinds of events in different parts of the world."
                +"<br />"
                +"<br />"
                + "Aunty B' Compere is that one MC who knows her onions when it comes to corporate and social events. Her profession is marked by excellence, which is why you won't find anyone like her anywhere - Yes, ANYWHERE."
                +"<br />"
                +"<br />"
                + "Aunty B is the best at creating a fun-filled atmosphere <span class=\"fw-600\">without being offensive</span> or <span class=\"fw-600\">exceeding boundaries</span> with her choice of words! Her style is unique, and her sense of humor is totally amazing."
                +"<br />"
                +"<br />"
                + "Don’t waste any more time. Who is emceeing your next event?"
                +"<br />"
                +"<br />"
                + "<span class=\"primary-color\">Book an appointment with us today. Why? The earlier you do it, the better it is.</span>"
            },
            new()
            {
                Id = 2,
                Name  ="Alaga Iduro/Ijoko",
                FaIcon = "",
                Tagline = "Alaga Iduro/Ijoko (African Traditional Weddings)",
                Summary = "",
                Content = "African traditional weddings are great due to the different aspects that they entail, such as alaga iduro/ijoko, aso ebi, groom prostration, eru iyawo packaging, dowry, and so on."
                +"<br />"
                +"<br />"
                + "However, it is equally important to have someone who is skilled enough to bring out the beauty in each aspect. Aunty B Compere is super exceptional in this. Her level of creativity is TOP-NOTCH."
                +"<br />"
                +"<br />"
                + "With a track record of displaying excellence in her profession as Alaga Iduro/Alaga Ijoko, you can be sure you will have your traditional wedding in grand style."
                +"<br />"
                +"<br />"
                + "Plus, Aunty B Compere is an expert in <span class=\"fw-600\">cross-cultural weddings;</span> she does it so well that her clients speak so highly of her. "
                +"<br />"
                +"<br />"
                + "<span class=\"primary-color\">Don't stress about that event; <span class=\"fw-600\">LET AUNTY B’ COMPERE TAKE CHARGE.</span></span>"
            },
            new()
            {
                Id = 3,
                Name  ="Clowning and Costuming",
                FaIcon = "",
                Tagline = "",
                Summary = "",
                Content = "Clowns bring a lot of colour and fun to parades, community gatherings, and commercial efforts. Clowns interact with the audience by waving, performing antics, and personally engaging both children and adults."
                +"<br />"
                +"<br />"
                + "Aunty B Compere does this in such a unique way that she stands out from any clown you've ever seen (I bet you have). We’ve made kings and courtiers laugh out loud because of not just our level of expertise in clowning but also our costuming."
                +"<br />"
                +"<br />"
                + "With a track record of displaying excellence in her profession as Alaga Iduro/Alaga Ijoko, you can be sure you will have your traditional wedding in grand style."
                +"<br />"
                +"<br />"
                + "Why are you bothering yourself about the clowns and the clown suits you will need for your next event, or maybe the next Halloween?"
                +"<br />"
                +"<br />"
                + "Here at Aunty B Compere, YOU are our priority, and whatever will bring a smile to your face, we are in for it - including clowning and costuming"
                +"<br />"
                +"<br />"
                +"<span class=\"primary-color\">Get in touch with us right away, and <span class=\"fw-600\">let’s get started!</span></span>"
            },
            new()
            {
                Id = 4,
                Name  ="Trainings",
                FaIcon = "",
                Tagline = "",
                Summary = "",
                Content = "Public speaking can make or break your career. It can also help you get ahead in life if done properly. Aunty B has been training people from all walks of life in public speaking for over 15 years and has helped them achieve their goals through this skill."
                +"<br />"
                +"<br />"
                + "We train our students with confidence building techniques that enable them to speak confidently in front of an audience no matter what situation they are placed in."
                +"<br />"
                +"<br />"
                + "Our courses also include tips on how to overcome nervousness when presenting, which is something most people experience before or during their speech."
                +"<br />"
                +"<br />"
                + "And, no, we don't just train public speakers; we also train ordinary men (both young and old) to be <span class=\"fw-600\">professional</span> masters of ceremonies and  <span class=\"fw-600\">elegant</span> Alaga Iduro and Ijokos. No one goes through our training programme and ends up without hitting it big (except you aren’t ready to put in the work)."
                +"<br />"
                +"<br />"
                + "Hoarding knowledge is not what we do here. <span class=\"fw-600\">If you’d like to tap from the wealth of knowledge Aunty B Compere</span> has, then <a href=\"/contact#contactSection\" class=\"fw-600\">CLICK HERE</a> to hop in right now and join this train before it speeds off."
            },
        };

        public Service Service { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }

            var service = _services.FirstOrDefault(s => s.Id == id);
            if (service == null)
            {
                return NotFound();
            }
            else
            {
                Service = service;
            }
            return Page();
        }
    }
}
