using Sptf.Data;
using Sptf.Domain.Models;
using Sptf.Domain.Repository;

namespace ClassLibrary1;

public class OrganizerRepository(SpotinizerContext spotinizerContext) : IOrganizerRepository
{
    private readonly SpotinizerContext _spotinizerContext = spotinizerContext;

    /*public Organizer CreateOrganizer(Organizer organizer)
    {

    }*/
}