using HomeHero_API.Data;
using HomeHero_API.Models;
using HomeHero_API.Models.Dto.Request_AreaDto;
using HomeHero_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HomeHero_API.Repository
{
    public class Request_AreaRepository : IRequest_AreaRepository
    {
        private readonly ApplicationDbContext _context;
        public Request_AreaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CreateRA(CreateRequest_AreaDto newRA)
        {
            _context.Request_Area.Add(new Request_Area
            {
                RequestID_Request = newRA.RequestID_Request,
                AreaID_Request = newRA.AreaID_Request,
            });
            return save();
        }

        public bool DeleteRA(Request_Area request_Area)
        {
            _context.Request_Area.Remove(request_Area);
            return save();
        }

        public Request_Area GetRA(int id)
        {
            return _context.Request_Area
                .Include(ra => ra.Area_RA)
                .Include(ra => ra.Request_RA)
                .FirstOrDefault(ra => ra.RequestAreaID == id);
        }


        public ICollection<Request_Area> GetAreasByRequest(int requestID)
        {
            return _context.Request_Area
                .Where(ra => ra.RequestID_Request == requestID)
                .Include(ra => ra.Area_RA)
                .Include(ra => ra.Request_RA)
                .ToList();
        }

        public ICollection<Request_Area> GetRequestByArea(string areaName)
        {
            return _context.Request_Area
                .Include(ra => ra.Area_RA)
                .Include(ra => ra.Request_RA)
                .Where(ra => ra.Area_RA.NameArea.Equals(areaName.Trim()))
                .ToList();
        }

        public ICollection<Request_Area> GetRequests_Areas()
        {
            return _context.Request_Area
                .Include(ra => ra.Area_RA)
                .Include(ra => ra.Request_RA)
                .ToList();
        }

        public bool save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool ExistRA(CreateRequest_AreaDto request_Area)
        {
            var ra = _context.Request_Area
                .FirstOrDefault(ra => ra.RequestID_Request == request_Area.RequestID_Request
                && ra.AreaID_Request == request_Area.AreaID_Request);
            if (ra != null)
            {
                return true;
            }
            return false;
        }
        public int lastID()
        {
            return _context.Request_Area.OrderByDescending(ra => ra.RequestAreaID).FirstOrDefault().RequestAreaID;
        }
    }
}
