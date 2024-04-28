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
            await CheckElectoralPositionsAsync();
            await CheckElectoralJourneysAsync();
        }

        private async Task CheckElectoralJourneysAsync()
        {
            if (!_context.ElectoralJourneys.Any())
            {
                _context.ElectoralJourneys.Add(new ElectoralJourney { 
                    Name = "Elección Secretario General", 
                    Date = DateTime.Parse("2024-04-27T05:56:01.997Z"),
                    DateFinish = DateTime.Parse("2024-04-27T16:56:01.997Z"),
                });
                _context.ElectoralJourneys.Add(new ElectoralJourney
                {
                    Name = "Elección Tesorero",
                    Date = DateTime.Parse("2024-03-27T06:56:01.997Z"),
                    DateFinish = DateTime.Parse("2024-03-27T18:56:01.997Z"),
                });
                _context.ElectoralJourneys.Add(new ElectoralJourney
                {
                    Name = "Elección Director Ejecutivo",
                    Date = DateTime.Parse("2024-03-26T06:56:01.997Z"),
                    DateFinish = DateTime.Parse("2024-03-26T18:56:01.997Z"),
                });
                _context.ElectoralJourneys.Add(new ElectoralJourney
                {
                    Name = "Elección Director de Operaciones",
                    Date = DateTime.Parse("2024-02-25T06:56:01.997Z"),
                    DateFinish = DateTime.Parse("2024-02-25T18:56:01.997Z"),
                });
                _context.ElectoralJourneys.Add(new ElectoralJourney
                {
                    Name = "Elección Delegado de Aula de Clases 2024",
                    Date = DateTime.Parse("2024-02-24T06:56:01.997Z"),
                    DateFinish = DateTime.Parse("2024-02-24T18:56:01.997Z"),
                });
                _context.ElectoralJourneys.Add(new ElectoralJourney
                {
                    Name = "Elección Delegado de Aula de Clases 20023",
                    Date = DateTime.Parse("2024-02-20T06:56:01.997Z"),
                    DateFinish = DateTime.Parse("2024-02-20T18:56:01.997Z"),
                });
                _context.ElectoralJourneys.Add(new ElectoralJourney
                {
                    Name = "Elección Coordinador de Eventos",
                    Date = DateTime.Parse("2024-03-22T06:56:01.997Z"),
                    DateFinish = DateTime.Parse("2024-03-22T18:56:01.997Z"),
                });
                _context.ElectoralJourneys.Add(new ElectoralJourney
                {
                    Name = "Elección Director de Decanos",
                    Date = DateTime.Parse("2024-03-15T06:56:01.997Z"),
                    DateFinish = DateTime.Parse("2024-03-15T18:56:01.997Z"),
                });
                _context.ElectoralJourneys.Add(new ElectoralJourney
                {
                    Name = "Elección Director de Bienestar",
                    Date = DateTime.Parse("2024-01-10T06:56:01.997Z"),
                    DateFinish = DateTime.Parse("2024-01-10T18:56:01.997Z"),
                });
                _context.ElectoralJourneys.Add(new ElectoralJourney
                {
                    Name = "Elección Representante Estudiantil 2024 1",
                    Date = DateTime.Parse("2024-02-10T06:56:01.997Z"),
                    DateFinish = DateTime.Parse("2024-02-10T18:56:01.997Z"),
                });
                _context.ElectoralJourneys.Add(new ElectoralJourney
                {
                    Name = "Elección Director Cultural 2024 1",
                    Date = DateTime.Parse("2024-03-11T06:56:01.997Z"),
                    DateFinish = DateTime.Parse("2024-03-11T18:56:01.997Z"),
                });
                _context.ElectoralJourneys.Add(new ElectoralJourney
                {
                    Name = "Elección Director Deportivo 2024 1",
                    Date = DateTime.Parse("2024-03-13T06:56:01.997Z"),
                    DateFinish = DateTime.Parse("2024-03-13T18:56:01.997Z"),
                });
                _context.ElectoralJourneys.Add(new ElectoralJourney
                {
                    Name = "Elección Director de I+D",
                    Date = DateTime.Parse("2024-03-17T06:56:01.997Z"),
                    DateFinish = DateTime.Parse("2024-03-17T18:56:01.997Z"),
                });
                _context.ElectoralJourneys.Add(new ElectoralJourney
                {
                    Name = "Elección Representante Consejo Estudiantil",
                    Date = DateTime.Parse("2024-04-22T06:56:01.997Z"),
                    DateFinish = DateTime.Parse("2024-04-22T18:56:01.997Z"),
                });
            }

            await _context.SaveChangesAsync();
        }
        private async Task CheckElectoralPositionsAsync()
        {
            if (!_context.ElectoralPositions.Any())
            {
                _context.ElectoralPositions.Add(new ElectoralPosition { Name = "Secretario General" });
                _context.ElectoralPositions.Add(new ElectoralPosition { Name = "Tesorero" });
                _context.ElectoralPositions.Add(new ElectoralPosition { Name = "Director Ejecutivo" });
                _context.ElectoralPositions.Add(new ElectoralPosition { Name = "Director de Operaciones" });
                _context.ElectoralPositions.Add(new ElectoralPosition { Name = "Delegado de Aula de Clases" });
                _context.ElectoralPositions.Add(new ElectoralPosition { Name = "Coordinador de Eventos" });
                _context.ElectoralPositions.Add(new ElectoralPosition { Name = "Director de Decanos" });
                _context.ElectoralPositions.Add(new ElectoralPosition { Name = "Director de Bienestar" });
                _context.ElectoralPositions.Add(new ElectoralPosition { Name = "Representante Estudiantil" });
                _context.ElectoralPositions.Add(new ElectoralPosition { Name = "Director Cultural" });
                _context.ElectoralPositions.Add(new ElectoralPosition { Name = "Director Deportivo" });
                _context.ElectoralPositions.Add(new ElectoralPosition { Name = "Director de I+D" });
                _context.ElectoralPositions.Add(new ElectoralPosition { Name = "Representante Consejo Estudiantil" });
                _context.ElectoralPositions.Add(new ElectoralPosition { Name = "Coordinador de intercambio" });
            }

            await _context.SaveChangesAsync();
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
