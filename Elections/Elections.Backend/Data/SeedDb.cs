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
                _ = _context.VotingStations.Add(new VotingStation
                {
                    Name = "Puesto Cafeteria",
                    Description = "Puesto ubicado en la Cafeteria",
                    Code = "CF",
                    Zonings = [
                    new Zoning() { ZoningNumber = "01" },
                    new Zoning() { ZoningNumber = "02"},
                    new Zoning() { ZoningNumber = "03"},
                    new Zoning() { ZoningNumber = "04"},
                    new Zoning() { ZoningNumber = "05"},
                    new Zoning() { ZoningNumber = "06"},
                    new Zoning() { ZoningNumber = "07"},
                    new Zoning() { ZoningNumber = "08"},
                    new Zoning() { ZoningNumber = "09"},
                    new Zoning() { ZoningNumber = "10"},
                    new Zoning() { ZoningNumber = "11"},
                    new Zoning() { ZoningNumber = "12"}
                ]
                });
                _context.VotingStations.Add(new VotingStation
                {
                    Name = "Puesto Biblioteca",
                    Description = "Puesto ubicado en la Biblioteca",
                    Code = "BBL",
                    Zonings = new List<Zoning>(){
                    new Zoning() { ZoningNumber = "01" },
                    new Zoning() { ZoningNumber = "02"},
                    new Zoning() { ZoningNumber = "03"},
                    new Zoning() { ZoningNumber = "04"},
                    new Zoning() { ZoningNumber = "05"},
                    new Zoning() { ZoningNumber = "06"},
                    new Zoning() { ZoningNumber = "07"},
                    new Zoning() { ZoningNumber = "08"},
                    new Zoning() { ZoningNumber = "09"},
                    new Zoning() { ZoningNumber = "10"},
                    new Zoning() { ZoningNumber = "11"},
                    new Zoning() { ZoningNumber = "12"}}
                });
                _context.VotingStations.Add(new VotingStation
                {
                    Name = "Puesto Plataforma",
                    Description = "Puesto ubicado en la Plataforma",
                    Code = "PLT",
                    Zonings = new List<Zoning>(){
                    new Zoning() { ZoningNumber = "01" },
                    new Zoning() { ZoningNumber = "02"},
                    new Zoning() { ZoningNumber = "03"},
                    new Zoning() { ZoningNumber = "04"},
                    new Zoning() { ZoningNumber = "05"},
                    new Zoning() { ZoningNumber = "06"},
                    new Zoning() { ZoningNumber = "07"},
                    new Zoning() { ZoningNumber = "08"},
                    new Zoning() { ZoningNumber = "09"},
                    new Zoning() { ZoningNumber = "10"},
                    new Zoning() { ZoningNumber = "11"},
                    new Zoning() { ZoningNumber = "12"}}
                });
                _context.VotingStations.Add(new VotingStation
                {
                    Name = "Puesto Edificio A",
                    Description = "Puesto ubicado en el Edificio A",
                    Code = "EDFA",
                    Zonings = new List<Zoning>(){
                    new Zoning() { ZoningNumber = "01" },
                    new Zoning() { ZoningNumber = "02"},
                    new Zoning() { ZoningNumber = "03"},
                    new Zoning() { ZoningNumber = "04"},
                    new Zoning() { ZoningNumber = "05"},
                    new Zoning() { ZoningNumber = "06"},
                    new Zoning() { ZoningNumber = "07"},
                    new Zoning() { ZoningNumber = "08"},
                    new Zoning() { ZoningNumber = "09"},
                    new Zoning() { ZoningNumber = "10"},
                    new Zoning() { ZoningNumber = "11"},
                    new Zoning() { ZoningNumber = "12"}}
                });
                _context.VotingStations.Add(new VotingStation
                {
                    Name = "Puesto Edificio B",
                    Description = "Puesto ubicado en el Edificio B",
                    Code = "EDFB",
                    Zonings = new List<Zoning>(){
                    new Zoning() { ZoningNumber = "01" },
                    new Zoning() { ZoningNumber = "02"},
                    new Zoning() { ZoningNumber = "03"},
                    new Zoning() { ZoningNumber = "04"},
                    new Zoning() { ZoningNumber = "05"},
                    new Zoning() { ZoningNumber = "06"},
                    new Zoning() { ZoningNumber = "07"},
                    new Zoning() { ZoningNumber = "08"},
                    new Zoning() { ZoningNumber = "09"},
                    new Zoning() { ZoningNumber = "10"},
                    new Zoning() { ZoningNumber = "11"},
                    new Zoning() { ZoningNumber = "12"}}
                });
                _context.VotingStations.Add(new VotingStation
                {
                    Name = "Puesto Edificio C",
                    Description = "Puesto ubicado en el Edificio C",
                    Code = "EDFC",
                    Zonings = new List<Zoning>(){
                    new() { ZoningNumber = "01" },
                    new Zoning() { ZoningNumber = "02"},
                    new Zoning() { ZoningNumber = "03"},
                    new Zoning() { ZoningNumber = "04"},
                    new Zoning() { ZoningNumber = "05"},
                    new Zoning() { ZoningNumber = "06"},
                    new Zoning() { ZoningNumber = "07"},
                    new Zoning() { ZoningNumber = "08"},
                    new Zoning() { ZoningNumber = "09"},
                    new Zoning() { ZoningNumber = "10"},
                    new Zoning() { ZoningNumber = "11"},
                    new Zoning() { ZoningNumber = "12"}}
                });
                _context.VotingStations.Add(new VotingStation
                {
                    Name = "Puesto Edificio D",
                    Description = "Puesto ubicado en el Edificio D",
                    Code = "EDFD",
                    Zonings = new List<Zoning>(){
                    new Zoning() { ZoningNumber = "01" },
                    new Zoning() { ZoningNumber = "02"},
                    new Zoning() { ZoningNumber = "03"},
                    new Zoning() { ZoningNumber = "04"},
                    new Zoning() { ZoningNumber = "05"},
                    new Zoning() { ZoningNumber = "06"},
                    new Zoning() { ZoningNumber = "07"},
                    new Zoning() { ZoningNumber = "08"},
                    new Zoning() { ZoningNumber = "09"},
                    new Zoning() { ZoningNumber = "10"},
                    new Zoning() { ZoningNumber = "11"},
                    new Zoning() { ZoningNumber = "12"}}
                });
                _context.VotingStations.Add(new VotingStation
                {
                    Name = "Puesto Observatiorio",
                    Description = "Puesto ubicado en el Observatiorio",
                    Code = "OBV",
                    Zonings = new List<Zoning>(){
                    new Zoning() { ZoningNumber = "01" },
                    new Zoning() { ZoningNumber = "02"},
                    new Zoning() { ZoningNumber = "03"},
                    new Zoning() { ZoningNumber = "04"},
                    new Zoning() { ZoningNumber = "05"},
                    new Zoning() { ZoningNumber = "06"},
                    new Zoning() { ZoningNumber = "07"},
                    new Zoning() { ZoningNumber = "08"},
                    new Zoning() { ZoningNumber = "09"},
                    new Zoning() { ZoningNumber = "10"},
                    new Zoning() { ZoningNumber = "11"},
                    new Zoning() { ZoningNumber = "12"}}
                });
                _context.VotingStations.Add(new VotingStation
                {
                    Name = "Puesto Plaza Colores",
                    Description = "Puesto ubicado en la Plaza Colores",
                    Code = "PLCL",
                    Zonings = new List<Zoning>(){
                    new Zoning() { ZoningNumber = "01" },
                    new Zoning() { ZoningNumber = "02"},
                    new Zoning() { ZoningNumber = "03"},
                    new Zoning() { ZoningNumber = "04"},
                    new Zoning() { ZoningNumber = "05"},
                    new Zoning() { ZoningNumber = "06"},
                    new Zoning() { ZoningNumber = "07"},
                    new Zoning() { ZoningNumber = "08"},
                    new Zoning() { ZoningNumber = "09"},
                    new Zoning() { ZoningNumber = "10"},
                    new Zoning() { ZoningNumber = "11"},
                    new Zoning() { ZoningNumber = "12"}}
                });
                _context.VotingStations.Add(new VotingStation
                {
                    Name = "Puesto Sistemas",
                    Description = "Puesto ubicado en la oficina de Sistemas",
                    Code = "ST",
                    Zonings = new List<Zoning>(){
                    new Zoning() { ZoningNumber = "01" },
                    new Zoning() { ZoningNumber = "02"},
                    new Zoning() { ZoningNumber = "03"},
                    new Zoning() { ZoningNumber = "04"},
                    new Zoning() { ZoningNumber = "05"},
                    new Zoning() { ZoningNumber = "06"},
                    new Zoning() { ZoningNumber = "07"},
                    new Zoning() { ZoningNumber = "08"},
                    new Zoning() { ZoningNumber = "09"},
                    new Zoning() { ZoningNumber = "10"},
                    new Zoning() { ZoningNumber = "11"},
                    new Zoning() { ZoningNumber = "12"}}
                });
                _context.VotingStations.Add(new VotingStation
                {
                    Name = "Puesto Parqueadero",
                    Description = "Puesto ubicado en el Parqueadero",
                    Code = "PRQ",
                    Zonings = new List<Zoning>(){
                    new Zoning() { ZoningNumber = "01" },
                    new Zoning() { ZoningNumber = "02"},
                    new Zoning() { ZoningNumber = "03"},
                    new Zoning() { ZoningNumber = "04"},
                    new Zoning() { ZoningNumber = "05"},
                    new Zoning() { ZoningNumber = "06"},
                    new Zoning() { ZoningNumber = "07"},
                    new Zoning() { ZoningNumber = "08"},
                    new Zoning() { ZoningNumber = "09"},
                    new Zoning() { ZoningNumber = "10"},
                    new Zoning() { ZoningNumber = "11"},
                    new Zoning() { ZoningNumber = "12"} }
                });
                _context.VotingStations.Add(new VotingStation
                {
                    Name = "Puesto Terraza",
                    Description = "Puesto ubicado en la Terraza",
                    Code = "TRR",
                    Zonings = new List<Zoning>(){
                    new Zoning() { ZoningNumber = "01" },
                    new Zoning() { ZoningNumber = "02"},
                    new Zoning() { ZoningNumber = "03"},
                    new Zoning() { ZoningNumber = "04"},
                    new Zoning() { ZoningNumber = "05"},
                    new Zoning() { ZoningNumber = "06"},
                    new Zoning() { ZoningNumber = "07"},
                    new Zoning() { ZoningNumber = "08"},
                    new Zoning() { ZoningNumber = "09"},
                    new Zoning() { ZoningNumber = "10"},
                    new Zoning() { ZoningNumber = "11"},
                    new Zoning() { ZoningNumber = "12"} }
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}
