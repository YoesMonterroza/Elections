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
            await CheckCountriesAsync();
            await CheckVotingStationsAsync();
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _ = _context.Countries.Add(new Country
                {
                    Name = "Colombia",
                    States =
                    [
                        new State()
                        {
                            Name = "Antioquia",
                            Cities = [
                                new() { Name = "Medellín" },
                                new() { Name = "Itagüí" },
                                new() { Name = "Envigado" },
                                new() { Name = "Bello" },
                                new() { Name = "Rionegro" },
                                new() { Name = "Marinilla" },
                            ]
                        },
                        new State()
                        {
                            Name = "Bogotá",
                            Cities = [
                                new() { Name = "Usaquen" },
                                new() { Name = "Champinero" },
                                new() { Name = "Santa fe" },
                                new() { Name = "Useme" },
                                new() { Name = "Bosa" },
                            ]
                        },
                    ]
                });
                _context.Countries.Add(new Country
                {
                    Name = "Estados Unidos",
                    States =
                    [
                        new State()
                        {
                            Name = "Florida",
                            Cities = [
                                new() { Name = "Orlando" },
                                new() { Name = "Miami" },
                                new() { Name = "Tampa" },
                                new() { Name = "Fort Lauderdale" },
                                new() { Name = "Key West" },
                            ]
                        },
                        new State()
                        {
                            Name = "Texas",
                            Cities = [
                                new() { Name = "Houston" },
                                new() { Name = "San Antonio" },
                                new() { Name = "Dallas" },
                                new() { Name = "Austin" },
                                new() { Name = "El Paso" },
                            ]
                        },
                    ]
                });
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
                    CityId = 1,
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
                    CityId = 1,
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
                    CityId = 1,
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
                    CityId = 1,
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
                    CityId = 1,
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
                    CityId = 1,
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
                    CityId = 1,
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
                    CityId = 1,
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
                    CityId = 1,
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
                    CityId = 1,
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
                    CityId = 1,
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
                    CityId = 1,
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

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "Colombia",
                    States =
                [
                new State()
        {
            Name = "Antioquia",
            Cities = [
                new() { Name = "Medellín" },
                new() { Name = "Itagüí" },
                new() { Name = "Envigado" },
                new() { Name = "Bello" },
                new() { Name = "Rionegro" },
                new() { Name = "Abejorral" },
                new() { Name = "Abriaquí" },
                new() { Name = "Alejandría" },
                new() { Name = "Amagá" },
                new() { Name = "Amalfi" },
                new() { Name = "Andes" },
                new() { Name = "Angelópolis" },

            ]
        },

        new State()
        {
            Name = "Cundinamarca",
            Cities = [
                new() { Name = "Chia" },
                new() { Name = "Sibate" },
                new() { Name = "Girardot" },
                new() { Name = "Facatativa" },
                new() { Name = "Funsa" },
                new() { Name = "Agua de Dios" },
                new() { Name = "Anapoima" },
                new() { Name = "Anolaima" },
                new() { Name = "Arbeláez" },
                new() { Name = "Caparrapí" },
                new() { Name = "Chaguaní" },
                new() { Name = "Chipaque" },
            ]
        },

        new State()
        {
            Name = "Quindio",
            Cities = [
                new() { Name = "Armenia" },
                new() { Name = "Buenavista" },
                new() { Name = "Calarca" },
                new() { Name = "Circasia" },
                new() { Name = "Córdoba" },
                new() { Name = "Filandia" },
                new() { Name = "Génova" },
                new() { Name = "La Tebaida" },
                new() { Name = "Montenegro" },
                new() { Name = "Pijao" },
                new() { Name = "Quimbaya" },
                new() { Name = "Salento" },

            ]
        },

        new State()
        {
            Name = "Risaralda",
            Cities = [
                new() { Name = "Apía" },
                new() { Name = "Balboa" },
                new() { Name = "Belén de Umbría" },
                new() { Name = "Dosquebradas" },
                new() { Name = "Guática" },
                new() { Name = "La Celia" },
                new() { Name = "La Virginia" },
                new() { Name = "Marsella" },
                new() { Name = "Mistrató" },
                new() { Name = "Pereira" },
                new() { Name = "Pueblo Rico" },
                new() { Name = "Quinchía" },
            ]
        },

        new State()
        {
            Name = "Chocó",
            Cities = [
                new() { Name = "Acandí" },
                new() { Name = "Alto Baudó" },
                new() { Name = "Atrato" },
                new() { Name = "Bagadó" },
                new() { Name = "Bahía Solano" },
                new() { Name = "Bajo Baudó" },
                new() { Name = "Bojayá" },
                new() { Name = "Carmen del Darien" },
                new() { Name = "Cértegui" },
                new() { Name = "Condoto" },
                new() { Name = "El Carmen de Atrato" },
                new() { Name = "Istmina" },
            ]
        },

        new State()
        {
            Name = "Boyacá",
            Cities = [
                new() { Name = "Almeida" },
                new() { Name = "Aquitania" },
                new() { Name = "Arcabuco" },
                new() { Name = "Belén" },
                new() { Name = "Berbeo" },
                new() { Name = "Betéitiva" },
                new() { Name = "Boavita" },
                new() { Name = "Boyacá" },
                new() { Name = "Briceño" },
                new() { Name = "Buenavista" },
                new() { Name = "Busbanzá" },
                new() { Name = "Caldas" },
            ]
        },

        new State()
        {
            Name = "Norte de Santander",
            Cities = [
                new() { Name = "Abrego" },
                new() { Name = "Arboledas" },
                new() { Name = "Bochalema" },
                new() { Name = "Bucarasica" },
                new() { Name = "Cachirá" },
                new() { Name = "Cácota" },
                new() { Name = "Chinácota" },
                new() { Name = "Chitagá" },
                new() { Name = "Convención" },
                new() { Name = "Cúcuta" },
                new() { Name = "Cucutilla" },
                new() { Name = "Durania" },
            ]
        },

        new State()
        {
            Name = "Santander",
            Cities = [
                new() { Name = "Aguada" },
                new() { Name = "Albania" },
                new() { Name = "Aratoca" },
                new() { Name = "Barbosa" },
                new() { Name = "Barichara" },
                new() { Name = "Barrancabermeja" },
                new() { Name = "Betulia" },
                new() { Name = "Bolívar" },
                new() { Name = "Bucaramanga" },
                new() { Name = "Cabrera" },
                new() { Name = "California" },
                new() { Name = "Capitanejo" },
            ]
        },

        new State()
        {
            Name = "Guainía",
            Cities = [
                new() { Name = "Barranco Minas" },
                new() { Name = "Cacahual" },
                new() { Name = "Inírida" },
                new() { Name = "La Guadalupe" },
                new() { Name = "Mapiripana" },
                new() { Name = "Morichal" },
                new() { Name = "Pana Pana" },
                new() { Name = "Puerto Colombia" },
                new() { Name = "San Felipe" },
            ]
        },

        new State()
        {
            Name = "Meta",
            Cities = [
                new() { Name = "Acacías" },
                new() { Name = "Barranca de Upía" },
                new() { Name = "Cabuyaro" },
                new() { Name = "Castilla la Nueva" },
                new() { Name = "Cubarral" },
                new() { Name = "Cumaral" },
                new() { Name = "El Calvario" },
                new() { Name = "El Castillo" },
                new() { Name = "El Dorado" },
                new() { Name = "Fuente de Oro" },
                new() { Name = "Granada" },
                new() { Name = "Guamal" },
            ]
        },

        new State()
        {
            Name = "Nariño",
            Cities = [
                new() { Name = "Aldana" },
                new() { Name = "Ancuya" },
                new() { Name = "Arboleda" },
                new() { Name = "Barbacoas" },
                new() { Name = "Belén" },
                new() { Name = "Buesaco" },
                new() { Name = "Chachagüí" },
                new() { Name = "Colón" },
                new() { Name = "Consaca" },
                new() { Name = "Contadero" },
                new() { Name = "Córdoba" },
                new() { Name = "Cuaspud" },
            ]
        },

        new State()
        {
            Name = "Valle del Cauca",
            Cities = [
                new() { Name = "Alcalá" },
                new() { Name = "Andalucía" },
                new() { Name = "Ansermanuevo" },
                new() { Name = "Argelia" },
                new() { Name = "Bolívar" },
                new() { Name = "Buenaventura" },
                new() { Name = "Bugalagrande" },
                new() { Name = "Caicedonia" },
                new() { Name = "Cali" },
                new() { Name = "Calima" },
                new() { Name = "Candelaria" },
                new() { Name = "Cartago" },
            ]
        },

        ]

                });




                _context.Countries.Add(new Country
                {
                    Name = "Estados Unidos",
                    States =
                [
                new State()
        {
            Name = "Alabama",
            Cities =
            [
                new() { Name = "Abbeville" },
                new() { Name = "Adamsville" },
                new() { Name = "Alabaster" },
                new() { Name = "Albertville" },
                new() { Name = "Alexander City" },
                new() { Name = "Alexandria" },
                new() { Name = "Aliceville" },
                new() { Name = "Andalusia" },
                new() { Name = "Anniston" },
                new() { Name = "Arab" },
                new() { Name = "Argo" },
                new() { Name = "Ashford" },

            ]
        },
        new State()
        {
            Name = "Alaska",
            Cities =
            [
                new() { Name = "Akutan" },
                new() { Name = "Anchor Point" },
                new() { Name = "Anchorage" },
                new() { Name = "Badger" },
                new() { Name = "Barrow" },
                new() { Name = "Bear Creek" },
                new() { Name = "Bethel" },
                new() { Name = "Bethel Census Area" },
                new() { Name = "Big Lake" },
                new() { Name = "Bristol Bay Borough" },
                new() { Name = "Butte" },
                new() { Name = "Chevak" },

            ]
        },

         new State()
        {
            Name = "Arizona",
            Cities =
            [
                new() { Name = "Ahwatukee Foothills" },
                new() { Name = "Ajo" },
                new() { Name = "Alhambra" },
                new() { Name = "Anthem" },
                new() { Name = "Apache County" },
                new() { Name = "Apache Junction" },
                new() { Name = "Arivaca Junction" },
                new() { Name = "Arizona City" },
                new() { Name = "Avenue B and C" },
                new() { Name = "Avondale" },
                new() { Name = "Avra Valley" },
                new() { Name = "Bagdad" },

            ]
        },

         new State()
        {
            Name = "Arkansas",
            Cities =
            [
                new() { Name = "Alexander" },
                new() { Name = "Alma" },
                new() { Name = "Arkadelphia" },
                new() { Name = "Arkansas City" },
                new() { Name = "Arkansas County" },
                new() { Name = "Ash Flat" },
                new() { Name = "Ashdown" },
                new() { Name = "Ashley County" },
                new() { Name = "Atkins" },
                new() { Name = "Augusta" },
                new() { Name = "Austin" },
                new() { Name = "Bald Knob" },

            ]
        },

         new State()
        {
            Name = "Montana",
            Cities =
            [
                new() { Name = "Absarokee" },
                new() { Name = "Anaconda" },
                new() { Name = "Baker" },
                new() { Name = "Beaverhead County" },
                new() { Name = "Belgrade" },
                new() { Name = "Big Horn County" },
                new() { Name = "Big Sky" },
                new() { Name = "Big Timber" },
                new() { Name = "Bigfork" },
                new() { Name = "Billings" },
                new() { Name = "Blaine County" },
                new() { Name = "Boulder" },

            ]
        },

         new State()
        {
            Name = "New Hampshire",
            Cities =
            [
                new() { Name = "Alexandria" },
                new() { Name = "Alstead" },
                new() { Name = "Andover" },
                new() { Name = "Antrim" },
                new() { Name = "Ashland" },
                new() { Name = "Atkinson" },
                new() { Name = "Auburn" },
                new() { Name = "Barnstead" },
                new() { Name = "Barrington" },
                new() { Name = "Bedford" },
                new() { Name = "Belknap County" },
                new() { Name = "Belmont" },

            ]
        },

         new State()
        {
            Name = "Oregon",
            Cities =
            [
                new() { Name = "Albany" },
                new() { Name = "Aloha" },
                new() { Name = "Altamont" },
                new() { Name = "Amity" },
                new() { Name = "Ashland" },
                new() { Name = "Astoria" },
                new() { Name = "Athena" },
                new() { Name = "Aumsville" },
                new() { Name = "Baker City" },
                new() { Name = "Baker County" },
                new() { Name = "Bandon" },
                new() { Name = "Banks" },

            ]
        },

         new State()
        {
            Name = "Texas",
            Cities =
            [
                new() { Name = "Abernathy" },
                new() { Name = "Abilene" },
                new() { Name = "Abram" },
                new() { Name = "Addison" },
                new() { Name = "Agua Dulce" },
                new() { Name = "Alamo" },
                new() { Name = "Alamo Heights" },
                new() { Name = "Albany" },
                new() { Name = "Aldine" },
                new() { Name = "Aledo" },
                new() { Name = "Alice" },
                new() { Name = "Alief" },

            ]
        },

         new State()
        {
            Name = "Washington",
            Cities =
            [
                new() { Name = "Aberdeen" },
                new() { Name = "Adams County" },
                new() { Name = "Ahtanum" },
                new() { Name = "Airway Heights" },
                new() { Name = "Alderton" },
                new() { Name = "Alderwood Manor" },
                new() { Name = "Algona" },
                new() { Name = "Allyn" },
                new() { Name = "Amboy" },
                new() { Name = "Ames Lake" },
                new() { Name = "Anacortes" },
                new() { Name = "Arlington" },

            ]
        },

         new State()
        {
            Name = "Vermont",
            Cities =
            [
                new() { Name = "Addison" },
                new() { Name = "Addison County" },
                new() { Name = "Arlington" },
                new() { Name = "Barre" },
                new() { Name = "Bellows Falls" },
                new() { Name = "Bennington" },
                new() { Name = "Bennington County" },
                new() { Name = "Brandon" },
                new() { Name = "Brattleboro" },
                new() { Name = "Bridport" },
                new() { Name = "Bristol" },
                new() { Name = "Burlington" },

            ]
        },

         new State()
        {
            Name = "Rhode Island",
            Cities =
            [
                new() { Name = "Ashaway" },
                new() { Name = "Barrington" },
                new() { Name = "Bradford" },
                new() { Name = "Bristol" },
                new() { Name = "Bristol County" },
                new() { Name = "Central Falls" },
                new() { Name = "Charlestown" },
                new() { Name = "Chepachet" },
                new() { Name = "Coventry" },
                new() { Name = "Cranston" },
                new() { Name = "Cumberland" },
                new() { Name = "Cumberland Hill" },

            ]
        },

         new State()
        {
            Name = "Pennsylvania",
            Cities =
            [
                new() { Name = "Abbottstown" },
                new() { Name = "Adams County" },
                new() { Name = "Adamstown" },
                new() { Name = "Akron" },
                new() { Name = "Albion" },
                new() { Name = "Alburtis" },
                new() { Name = "Aldan" },
                new() { Name = "Aliquippa" },
                new() { Name = "Allegheny County" },
                new() { Name = "Alleghenyville" },
                new() { Name = "Allentown" },
                new() { Name = "Allison Park" },

            ]
        },

    ]
                });



                _context.Countries.Add(new Country
                {
                    Name = "France",
                    States =
                [
                new State()
        {
            Name = "Nouvelle-Aquitaine",
            Cities =
            [
                new() { Name = "Abzac" },
                new() { Name = "Agen" },
                new() { Name = "Agonac" },
                new() { Name = "Ahetze" },
                new() { Name = "Ahun" },
                new() { Name = "Aiffres" },
                new() { Name = "Aigre" },
                new() { Name = "Aiguillon" },
                new() { Name = "Airvault" },
                new() { Name = "Aixe-sur-Vienne" },
                new() { Name = "Ajain" },
                new() { Name = "Allassac" },



            ]
        },
        new State()
        {
            Name = "Île-de-France",
            Cities =
            [
                new() { Name = "Ableiges" },
                new() { Name = "Ablis" },
                new() { Name = "Ablon-sur-Seine" },
                new() { Name = "Achères" },
                new() { Name = "Achères-la-Forêt" },
                new() { Name = "Alfortville" },
                new() { Name = "Andilly" },
                new() { Name = "Andrésy" },
                new() { Name = "Angerville" },
                new() { Name = "Angervilliers" },
                new() { Name = "Annet-sur-Marne" },
                new() { Name = "Antony" },



            ]
        },

         new State()
        {
            Name = "Auvergne-Rhône-Alpes",
            Cities =
            [
                new() { Name = "Abondance" },
                new() { Name = "Abrest" },
                new() { Name = "Aigueblanche" },
                new() { Name = "Aigueperse" },
                new() { Name = "Aime" },
                new() { Name = "Ainay-le-Château" },
                new() { Name = "Aiton" },
                new() { Name = "Aix-les-Bains" },
                new() { Name = "Alba-la-Romaine" },
                new() { Name = "Albens" },
                new() { Name = "Albertville" },
                new() { Name = "Albigny-sur-Saône" },



            ]
        },

         new State()
        {
            Name = "Occitanie",
            Cities =
            [
                new() { Name = "Abeilhan" },
                new() { Name = "Agde" },
                new() { Name = "Aiguefonde" },
                new() { Name = "Aigues-Mortes" },
                new() { Name = "Aigues-Vives" },
                new() { Name = "Aimargues" },
                new() { Name = "Albi" },
                new() { Name = "Albias" },
                new() { Name = "Alénya" },
                new() { Name = "Alès" },
                new() { Name = "Alignan-du-Vent" },
                new() { Name = "Alzonne" },

            ]
        },

         new State()
        {
            Name = "Pays-de-la-Loire",
            Cities =
            [
                new() { Name = "Abbaretz" },
                new() { Name = "Ahuillé" },
                new() { Name = "Aigné" },
                new() { Name = "Aizenay" },
                new() { Name = "Allonnes" },
                new() { Name = "Ancenis" },
                new() { Name = "Andard" },
                new() { Name = "Andouillé" },
                new() { Name = "Andrezé" },
                new() { Name = "Anetz" },
                new() { Name = "Angers" },
                new() { Name = "Angles" },

            ]
        },

         new State()
        {
            Name = "Normandie",
            Cities =
            [
                new() { Name = "Ablon" },
                new() { Name = "Acquigny" },
                new() { Name = "Agneaux" },
                new() { Name = "Agon-Coutainville" },
                new() { Name = "Alençon" },
                new() { Name = "Alizay" },
                new() { Name = "Amfreville" },
                new() { Name = "Andé" },
                new() { Name = "Angerville-l’Orcher" },
                new() { Name = "Argences" },
                new() { Name = "Argentan" },
                new() { Name = "Arnières-sur-Iton" },



            ]
        },

         new State()
        {
            Name = "Bretagne",
            Cities =
            [
                new() { Name = "Acigné" },
                new() { Name = "Allaire" },
                new() { Name = "Amanlis" },
                new() { Name = "Ambon" },
                new() { Name = "Antrain" },
                new() { Name = "Argentré-du-Plessis" },
                new() { Name = "Arradon" },
                new() { Name = "Arzano" },
                new() { Name = "Arzon" },
                new() { Name = "Audierne" },
                new() { Name = "Augan" },
                new() { Name = "Auray" },

            ]
        },

         new State()
        {
            Name = "Centre-Val de Loire",
            Cities =
            [
                new() { Name = "Abilly" },
                new() { Name = "Abondant" },
                new() { Name = "Aigurande" },
                new() { Name = "Ambillou" },
                new() { Name = "Amboise" },
                new() { Name = "Amilly" },
                new() { Name = "Anet" },
                new() { Name = "Ardentes" },
                new() { Name = "Argenton-sur-Creuse" },
                new() { Name = "Argent-sur-Sauldre" },
                new() { Name = "Arrou" },
                new() { Name = "Artannes-sur-Indre" },
            ]
        },

         new State()
        {
            Name = "Grand-Est",
            Cities =
            [
                new() { Name = "Abreschviller" },
                new() { Name = "Achenheim" },
                new() { Name = "Aiglemont" },
                new() { Name = "Aix-en-Othe" },
                new() { Name = "Algolsheim" },
                new() { Name = "Algrange" },
                new() { Name = "Alsting" },
                new() { Name = "Altkirch" },
                new() { Name = "Altorf" },
                new() { Name = "Amanvillers" },
                new() { Name = "Ammerschwihr" },
                new() { Name = "Amnéville" },



            ]
        },

         new State()
        {
            Name = "Hauts-de-France",
            Cities =
            [
                new() { Name = "Abbeville" },
                new() { Name = "Ablain-Saint-Nazaire" },
                new() { Name = "Abscon" },
                new() { Name = "Achicourt" },
                new() { Name = "Achiet-le-Grand" },
                new() { Name = "Agnetz" },
                new() { Name = "Agny" },
                new() { Name = "Ailly-sur-Noye" },
                new() { Name = "Ailly-sur-Somme" },
                new() { Name = "Airaines" },
                new() { Name = "Aire-sur-la-Lys" },
                new() { Name = "Aix-Noulette" },


            ]
        },


    ]
                });


                _context.Countries.Add(new Country
                {
                    Name = "Italy",
                    States =
                [
                new State()
        {
            Name = "Abruzzo",
            Cities =
            [
                new() { Name = "Abbateggio" },
                new() { Name = "Acciano" },
                new() { Name = "Aielli" },
                new() { Name = "Alanno" },
                new() { Name = "Alba Adriatica" },
                new() { Name = "Alfedena" },
                new() { Name = "Altino" },
                new() { Name = "Ancarano" },
                new() { Name = "Archi" },
                new() { Name = "Ari" },
                new() { Name = "Arielli" },
                new() { Name = "Arsita" },


            ]
        },
        new State()
        {
            Name = "Campania",
            Cities =
            [
                new() { Name = "Acerno" },
                new() { Name = "Acerra" },
                new() { Name = "Afragola" },
                new() { Name = "Agerola" },
                new() { Name = "Agropoli" },
                new() { Name = "Aiello del Sabato" },
                new() { Name = "Ailano" },
                new() { Name = "Airola" },
                new() { Name = "Albanella" },
                new() { Name = "Alfano" },
                new() { Name = "Alife" },
                new() { Name = "Altavilla Irpina" },


            ]
        },

         new State()
        {
            Name = "Marche",
            Cities =
            [
                new() { Name = "Acqualagna" },
                new() { Name = "Acquasanta Terme" },
                new() { Name = "Acquaviva Picena" },
                new() { Name = "Agugliano" },
                new() { Name = "Altidona" },
                new() { Name = "Amandola" },
                new() { Name = "Ancona" },
                new() { Name = "Apecchio" },
                new() { Name = "Apiro" },
                new() { Name = "Appignano" },
                new() { Name = "Appignano del Tronto" },
                new() { Name = "Arcevia" },


            ]
        },

         new State()
        {
            Name = "Lazio",
            Cities =
            [
                new() { Name = "Accumoli" },
                new() { Name = "Acquafondata" },
                new() { Name = "Acquapendente" },
                new() { Name = "Acuto" },
                new() { Name = "Affile" },
                new() { Name = "Agosta" },
                new() { Name = "Alatri" },
                new() { Name = "Albano Laziale" },
                new() { Name = "Albuccione" },
                new() { Name = "Allumiere" },
                new() { Name = "Alvito" },
                new() { Name = "Amaseno" },


            ]
        },

         new State()
        {
            Name = "Apulia",
            Cities =
            [
                new() { Name = "Accadia" },
                new() { Name = "Acquarica del Capo" },
                new() { Name = "Adelfia" },
                new() { Name = "Alberobello" },
                new() { Name = "Alberona" },
                new() { Name = "Alessano" },
                new() { Name = "Alezio" },
                new() { Name = "Alliste" },
                new() { Name = "Altamura" },
                new() { Name = "Andrano" },
                new() { Name = "Andria" },
                new() { Name = "Anzano di Puglia" },


            ]
        },

         new State()
        {
            Name = "Molise",
            Cities =
            [
                new() { Name = "Acquaviva Collecroce" },
                new() { Name = "Acquaviva d'Isernia" },
                new() { Name = "Agnone" },
                new() { Name = "Bagnoli del Trigno" },
                new() { Name = "Baranello" },
                new() { Name = "Belmonte del Sannio" },
                new() { Name = "Bojano" },
                new() { Name = "Bonefro" },
                new() { Name = "Busso" },
                new() { Name = "Campobasso" },
                new() { Name = "Campochiaro" },
                new() { Name = "Campodipietra" },


            ]
        },

         new State()
        {
            Name = "Calabria",
            Cities =
            [
                new() { Name = "Acconia" },
                new() { Name = "Acquaformosa" },
                new() { Name = "Acquappesa" },
                new() { Name = "Acquaro" },
                new() { Name = "Acri" },
                new() { Name = "Africo Nuovo" },
                new() { Name = "Africo Vecchio" },
                new() { Name = "Agnana Calabra" },
                new() { Name = "Aiello Calabro" },
                new() { Name = "Aieta" },
                new() { Name = "Albi" },
                new() { Name = "Albidona" },


            ]
        },

         new State()
        {
            Name = "Lombardy",
            Cities =
            [
                new() { Name = "Abbadia Cerreto" },
                new() { Name = "Abbadia Lariana" },
                new() { Name = "Abbazia" },
                new() { Name = "Abbiategrasso" },
                new() { Name = "Acquafredda" },
                new() { Name = "Acquanegra Cremonese" },
                new() { Name = "Adrara San Martino" },
                new() { Name = "Adrara San Rocco" },
                new() { Name = "Adro" },
                new() { Name = "Agnadello" },
                new() { Name = "Agnosine" },
                new() { Name = "Agra" },


            ]
        },

         new State()
        {
            Name = "Basilicata",
            Cities =
            [
                new() { Name = "Abriola" },
                new() { Name = "Accettura" },
                new() { Name = "Acerenza" },
                new() { Name = "Albano di Lucania" },
                new() { Name = "Aliano" },
                new() { Name = "Anzi" },
                new() { Name = "Armento" },
                new() { Name = "Atella" },
                new() { Name = "Avigliano" },
                new() { Name = "Balvano" },
                new() { Name = "Banzi" },
                new() { Name = "Baragiano" },


            ]
        },

         new State()
        {
            Name = "Aosta Valley",
            Cities =
            [
                new() { Name = "Allein" },
                new() { Name = "Antagnod" },
                new() { Name = "Antey-Saint-Andrè" },
                new() { Name = "Aosta" },
                new() { Name = "Arnad" },
                new() { Name = "Arvier" },
                new() { Name = "Avise" },
                new() { Name = "Ayas" },
                new() { Name = "Aymavilles" },
                new() { Name = "Bard" },
                new() { Name = "Berriat" },
                new() { Name = "Bionaz" },

            ]
        },

         new State()
        {
            Name = "Liguria",
            Cities =
            [
                new() { Name = "Airole" },
                new() { Name = "Alassio" },
                new() { Name = "Albenga" },
                new() { Name = "Albisola Marina" },
                new() { Name = "Albisola Superiore" },
                new() { Name = "Altare" },
                new() { Name = "Ameglia" },
                new() { Name = "Andora" },
                new() { Name = "Apricale" },
                new() { Name = "Aquila di Arroscia" },
                new() { Name = "Arcola" },
                new() { Name = "Arenzano" },


            ]
        },

         new State()
        {
            Name = "Emilia-Romagna",
            Cities =
            [
                new() { Name = "Agazzano" },
                new() { Name = "Albareto" },
                new() { Name = "Alberi" },
                new() { Name = "Albinea" },
                new() { Name = "Alfonsine" },
                new() { Name = "Alseno" },
                new() { Name = "Altedo" },
                new() { Name = "Anzola dell'Emilia" },
                new() { Name = "Arceto" },
                new() { Name = "Argelato" },
                new() { Name = "Argenta" },
                new() { Name = "Argine" },
            ]
        },

    ]
                });


                _context.Countries.Add(new Country
                {
                    Name = "Germany",
                    States =
                [
                new State()
        {
            Name = "Baden-Württemberg",
            Cities =
            [
                new() { Name = "Aach" },
                new() { Name = "Aalen" },
                new() { Name = "Abstatt" },
                new() { Name = "Abtsgmünd" },
                new() { Name = "Achern" },
                new() { Name = "Achstetten" },
                new() { Name = "Adelberg" },
                new() { Name = "Adelmannsfelden" },
                new() { Name = "Adelsheim" },
                new() { Name = "Affalterbach" },
                new() { Name = "Aglasterhausen" },
                new() { Name = "Aichelberg" },

            ]
        },
        new State()
        {
            Name = "Lower Saxony",
            Cities =
            [
                new() { Name = "Abbesbüttel" },
                new() { Name = "Achim" },
                new() { Name = "Adelebsen" },
                new() { Name = "Adelheidsdorf" },
                new() { Name = "Adenbüttel" },
                new() { Name = "Adendorf" },
                new() { Name = "Adenstedt" },
                new() { Name = "Aerzen" },
                new() { Name = "Agathenburg" },
                new() { Name = "Ahausen" },
                new() { Name = "Ahlden" },
                new() { Name = "Ahlerstedt" },



            ]
        },

         new State()
        {
            Name = "Bavaria",
            Cities =
            [
                new() { Name = "Abenberg" },
                new() { Name = "Abensberg" },
                new() { Name = "Absberg" },
                new() { Name = "Achslach" },
                new() { Name = "Adelsdorf" },
                new() { Name = "Adelshofen" },
                new() { Name = "Adelsried" },
                new() { Name = "Adelzhausen" },
                new() { Name = "Adlkofen" },
                new() { Name = "Affing" },
                new() { Name = "Aham" },
                new() { Name = "Aholfing" },



            ]
        },

         new State()
        {
            Name = "Berlin",
            Cities =
            [
                new() { Name = "Adlershof" },
                new() { Name = "Altglienicke" },
                new() { Name = "Alt-Hohenschönhausen" },
                new() { Name = "Alt-Treptow" },
                new() { Name = "Baumschulenweg" },
                new() { Name = "Berlin" },
                new() { Name = "Berlin Köpenick" },
                new() { Name = "Berlin Treptow" },
                new() { Name = "Biesdorf" },
                new() { Name = "Blankenburg" },
                new() { Name = "Blankenfelde" },
                new() { Name = "Bohnsdorf" },

            ]
        },

         new State()
        {
            Name = "Saxony-Anhalt",
            Cities =
            [
                new() { Name = "Abtsdorf" },
                new() { Name = "Ahlsdorf" },
                new() { Name = "Aken" },
                new() { Name = "Allstedt" },
                new() { Name = "Alsleben" },
                new() { Name = "Angern" },
                new() { Name = "Angersdorf" },
                new() { Name = "Annaburg" },
                new() { Name = "Apollensdorf" },
                new() { Name = "Arneburg" },
                new() { Name = "Aschersleben" },
                new() { Name = "Atzendorf" },

            ]
        },

         new State()
        {
            Name = "Brandenburg",
            Cities =
            [
                new() { Name = "Alt Tucheband" },
                new() { Name = "Altdöbern" },
                new() { Name = "Altlandsberg" },
                new() { Name = "Angermünde" },
                new() { Name = "Bad Belzig" },
                new() { Name = "Bad Freienwalde" },
                new() { Name = "Bad Liebenwerda" },
                new() { Name = "Bad Saarow" },
                new() { Name = "Bad Wilsnack" },
                new() { Name = "Baruth" },
                new() { Name = "Beelitz" },
                new() { Name = "Beeskow" },

            ]
        },

         new State()
        {
            Name = "Bremen",
            Cities =
            [
                new() { Name = "Bremen" },
                new() { Name = "Bremerhaven" },
                new() { Name = "Burglesum" },
                new() { Name = "Vegesack" },
                new() { Name = "Alsterdorf" },
                new() { Name = "Altona" },
                new() { Name = "Barmbek-Nord" },
                new() { Name = "Bergedorf" },
                new() { Name = "Bergstedt" },
                new() { Name = "Borgfelde" },
                new() { Name = "Duvenstedt" },
                new() { Name = "Eidelstedt" },

            ]
        },

         new State()
        {
            Name = "Hamburg",
            Cities =
            [
                new() { Name = "Alsterdorf" },
                new() { Name = "Altona" },
                new() { Name = "Barmbek-Nord" },
                new() { Name = "Bergedorf" },
                new() { Name = "Bergstedt" },
                new() { Name = "Borgfelde" },
                new() { Name = "Duvenstedt" },
                new() { Name = "Eidelstedt" },
                new() { Name = "Eimsbüttel" },
                new() { Name = "Farmsen-Berne" },
                new() { Name = "Fuhlsbüttel" },
                new() { Name = "Hamburg" },



            ]
        },

         new State()
        {
            Name = "Hesse",
            Cities =
            [
                new() { Name = "Albshausen" },
                new() { Name = "Alheim" },
                new() { Name = "Allendorf" },
                new() { Name = "Alsbach-Hähnlein" },
                new() { Name = "Alsfeld" },
                new() { Name = "Alten Buseck" },
                new() { Name = "Altenstadt" },
                new() { Name = "Amöneburg" },
                new() { Name = "Aßlar" },
                new() { Name = "Babenhausen" },
                new() { Name = "Bad Arolsen" },
                new() { Name = "Bad Camberg" },

            ]
        },

         new State()
        {
            Name = "Rhineland-Palatinate",
            Cities =
            [
                new() { Name = "Aach" },
                new() { Name = "Adenau" },
                new() { Name = "Ahrbrück" },
                new() { Name = "Albersweiler" },
                new() { Name = "Albig" },
                new() { Name = "Albisheim" },
                new() { Name = "Alpenrod" },
                new() { Name = "Alsdorf" },
                new() { Name = "Alsenz" },
                new() { Name = "Alsheim" },
                new() { Name = "Altenahr" },
                new() { Name = "Altendiez" },

            ]
        },

         new State()
        {
            Name = "Saarland",
            Cities =
            [
                new() { Name = "Beckingen" },
                new() { Name = "Bexbach" },
                new() { Name = "Blieskastel" },
                new() { Name = "Bous" },
                new() { Name = "Britten" },
                new() { Name = "Dillingen" },
                new() { Name = "Ensdorf" },
                new() { Name = "Eppelborn" },
                new() { Name = "Freisen" },
                new() { Name = "Friedrichsthal" },
                new() { Name = "Fürstenhausen" },
                new() { Name = "Gersheim" },
            ]
        },

         new State()
        {
            Name = "Saxony",
            Cities =
            [
                new() { Name = "Adorf" },
                new() { Name = "Albertstadt" },
                new() { Name = "Altenberg" },
                new() { Name = "Altmittweida" },
                new() { Name = "Annaberg-Buchholz" },
                new() { Name = "Arzberg" },
                new() { Name = "Aue" },
                new() { Name = "Auerbach" },
                new() { Name = "Augustusburg" },
                new() { Name = "Bad Brambach" },
                new() { Name = "Bad Düben" },
                new() { Name = "Bad Elster" },

            ]
        },

    ]
                });




                _context.Countries.Add(new Country
                {
                    Name = "Peru",
                    States =
                [
                new State()
        {
            Name = "Huancavelica",
            Cities =
            [
                new() { Name = "Huancavelica" },
                new() { Name = "Huaytara" },
                new() { Name = "Pampas" },
            ]
        },
        new State()
        {
            Name = "Áncash",
            Cities =
            [
                new() { Name = "Asuncion" },
                new() { Name = "Carás" },
                new() { Name = "Carhuaz" },
                new() { Name = "Chimbote" },
                new() { Name = "Coishco" },
                new() { Name = "Huaraz" },
                new() { Name = "Huarmey" },
                new() { Name = "Pomabamba" },
                new() { Name = "Provincia de Aija" },
                new() { Name = "Provincia de Carhuaz" },
                new() { Name = "Provincia de Casma" },
                new() { Name = "Provincia de Corongo" },
            ]
        },

         new State()
        {
            Name = "Arequipa",
            Cities =
            [
                new() { Name = "Acarí" },
                new() { Name = "Arequipa" },
                new() { Name = "Camaná" },
                new() { Name = "Ccolo" },
                new() { Name = "Chivay" },
                new() { Name = "Cocachacra" },
                new() { Name = "Cotahuasi" },
                new() { Name = "Huarancante" },
                new() { Name = "Huarichancara" },
                new() { Name = "Jatun Orcochiri" },
                new() { Name = "Jayune" },
                new() { Name = "Llongasora" },
            ]
        },

         new State()
        {
            Name = "Amazonas",
            Cities =
            [
                new() { Name = "Bagua Grande" },
                new() { Name = "Cajaruro" },
                new() { Name = "Chachapoyas" },
                new() { Name = "Condorcanqui" },
                new() { Name = "La Peca" },
                new() { Name = "Provincia de Bagua" },
                new() { Name = "Provincia de Bongará" },
                new() { Name = "Provincia de Luya" },
                new() { Name = "Utcubamba" },
            ]
        },

         new State()
        {
            Name = "Huanuco",
            Cities =
            [
                new() { Name = "Ambo" },
                new() { Name = "Huacaybamba" },
                new() { Name = "Huánuco" },
                new() { Name = "La Unión" },
                new() { Name = "Lauricocha" },
                new() { Name = "Llata" },
                new() { Name = "Provincia de Ambo" },
                new() { Name = "Provincia de Huánuco" },
                new() { Name = "Provincia de Marañón" },
                new() { Name = "Puerto Inca" },
                new() { Name = "San Miguel de Cauri" },
                new() { Name = "Tingo María" },
            ]
        },

         new State()
        {
            Name = "Cajamarca",
            Cities =
            [
                new() { Name = "Bambamarca" },
                new() { Name = "Bellavista" },
                new() { Name = "Cajabamba" },
                new() { Name = "Cajamarca" },
                new() { Name = "Celendín" },
                new() { Name = "Chota" },
                new() { Name = "Jaén" },
                new() { Name = "Provincia de Chota" },
                new() { Name = "Provincia de Cutervo" },
                new() { Name = "Provincia de Jaén" },
                new() { Name = "San Ignacio" },
            ]
        },

         new State()
        {
            Name = "Cusco",
            Cities =
            [
                new() { Name = "Anta" },
                new() { Name = "Cahuanuyo" },
                new() { Name = "Calca" },
                new() { Name = "Callanca" },
                new() { Name = "Ccaquiracunca" },
                new() { Name = "Ccuntuma" },
                new() { Name = "Checacupe" },
                new() { Name = "Checca" },
                new() { Name = "Chignayhua" },
                new() { Name = "Chinchero" },
                new() { Name = "Combapata" },
                new() { Name = "Conchopata" },
            ]
        },

         new State()
        {
            Name = "Ayacucho",
            Cities =
            [
                new() { Name = "Ayacucho" },
                new() { Name = "Ayna" },
                new() { Name = "Coracora" },
                new() { Name = "Huanta" },
                new() { Name = "Paucar Del Sara Sara" },
                new() { Name = "Provincia de Huanta" },
                new() { Name = "Provincia de La Mar" },
                new() { Name = "Provincia de Lucanas" },
                new() { Name = "Provincia de Sucre" },
                new() { Name = "Puquio" },
                new() { Name = "San Miguel" },
                new() { Name = "Tambo" },
            ]
        },

         new State()
        {
            Name = "Junín",
            Cities =
            [
                new() { Name = "Acolla" },
                new() { Name = "Carhuamayo" },
                new() { Name = "Chanchamayo" },
                new() { Name = "Chupaca" },
                new() { Name = "Concepción" },
                new() { Name = "Huancayo" },
                new() { Name = "Huasahuasi" },
                new() { Name = "Huayucachi" },
                new() { Name = "Jauja" },
                new() { Name = "Junín" },
                new() { Name = "La Oroya" },
                new() { Name = "Mazamari" },
            ]
        },

         new State()
        {
            Name = "Apurímac",
            Cities =
            [
                new() { Name = "Abancay" },
                new() { Name = "Andahuaylas" },
                new() { Name = "Provincia de Abancay" },
                new() { Name = "Provincia de Grau" },
                new() { Name = "San Jerónimo" },
                new() { Name = "Talavera" },
            ]
        },

         new State()
        {
            Name = "Ica",
            Cities =
            [
                new() { Name = "Chincha Alta" },
                new() { Name = "Ica" },
                new() { Name = "Los Aquijes" },
                new() { Name = "Minas de Marcona" },
                new() { Name = "Nazca" },
                new() { Name = "Palpa" },
                new() { Name = "Paracas" },
                new() { Name = "Pisco" },
                new() { Name = "Provincia de Chincha" },
                new() { Name = "Provincia de Ica" },
                new() { Name = "Provincia de Nazca" },
                new() { Name = "Provincia de Palpa" },

            ]
        },

         new State()
        {
            Name = "Puno",
            Cities =
            [
                new() { Name = "Atuncolla" },
                new() { Name = "Ayaviri" },
                new() { Name = "Azángaro" },
                new() { Name = "Desaguadero" },
                new() { Name = "El Collao" },
                new() { Name = "Hacienda Huancane" },
                new() { Name = "Ilave" },
                new() { Name = "Juli" },
                new() { Name = "Juliaca" },
                new() { Name = "La Rinconada" },
                new() { Name = "Lampa" },
                new() { Name = "Macusani" },
            ]
        },

    ]
                });

            }
            await _context.SaveChangesAsync();
        }
    }
}
