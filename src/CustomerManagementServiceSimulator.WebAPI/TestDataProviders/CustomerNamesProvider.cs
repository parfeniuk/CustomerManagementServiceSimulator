namespace CustomerManagementServiceSimulator.WebAPI.TestDataProviders
{
    public static class CustomerNamesProvider
    {
        private static readonly string[] FirstNames =
        [
            "Leia",
            "Sadie",
            "Jose",
            "Sara",
            "Frank",
            "Dewey",
            "Tomas",
            "Joel",
            "Lukas",
            "Carlos"
        ];

        private static readonly string[] LastNames =
        [
            "Liberty",
            "Ray",
            "Harrison",
            "Ronan",
            "Drew",
            "Powell",
            "Larsen",
            "Chan",
            "Anderson",
            "Lane"
        ];

        public static string GetRandomFirstName()
        {
            return FirstNames[Random.Shared.Next(FirstNames.Length)];
        }

        public static string GetRandomLastName()
        {
            return LastNames[Random.Shared.Next(LastNames.Length)];
        }
    }
}
