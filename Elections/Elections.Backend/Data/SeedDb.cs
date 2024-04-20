using Elections.Shared.Entities;

namespace Elections.Backend.Data
{

    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckVotingStationsAsync();
        }

        private async Task CheckVotingStationsAsync()
        {
            if (!_context.VotingStations.Any())
            {
                _context.VotingStations.Add(new VotingStation { Name = "Puesto Cafeteria", Description = "Puesto ubicado en la Cafeteria", Code = "CF" });
                _context.VotingStations.Add(new VotingStation { Name = "Puesto Biblioteca", Description = "Puesto ubicado en la Biblioteca", Code = "BBL" });
                _context.VotingStations.Add(new VotingStation { Name = "Puesto Plataforma", Description = "Puesto ubicado en la Plataforma", Code = "PLT" });
                _context.VotingStations.Add(new VotingStation { Name = "Puesto Edificio A", Description = "Puesto ubicado en el Edificio A", Code = "EDFA" });
                _context.VotingStations.Add(new VotingStation { Name = "Puesto Edificio B", Description = "Puesto ubicado en el Edificio B", Code = "EDFB" });
                _context.VotingStations.Add(new VotingStation { Name = "Puesto Edificio C", Description = "Puesto ubicado en el Edificio C", Code = "EDFC" });
                _context.VotingStations.Add(new VotingStation { Name = "Puesto Edificio D", Description = "Puesto ubicado en el Edificio D", Code = "EDFD" });
                _context.VotingStations.Add(new VotingStation { Name = "Puesto Observatiorio", Description = "Puesto ubicado en el Observatiorio", Code = "OBV" });
                _context.VotingStations.Add(new VotingStation { Name = "Puesto Plaza Colores", Description = "Puesto ubicado en la Plaza Colores", Code = "PLCL" });
                _context.VotingStations.Add(new VotingStation { Name = "Puesto Sistemas", Description = "Puesto ubicado en la oficina de Sistemas", Code = "ST" });
                _context.VotingStations.Add(new VotingStation { Name = "Puesto Parqueadero", Description = "Puesto ubicado en el Parqueadero", Code = "PRQ" });
                _context.VotingStations.Add(new VotingStation { Name = "Puesto Terraza", Description = "Puesto ubicado en la Terraza", Code = "TRR" });
            }

            await _context.SaveChangesAsync();
        }
    }
}
