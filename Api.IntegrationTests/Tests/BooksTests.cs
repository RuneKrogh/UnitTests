using Generated;


namespace Api.IntegrationTests.Tests;

public class BooksTests : ApiTestBase
{
    /// <summary>
    /// Verify that a book can be successfully created when all required fields are provided.
    /// </summary>
    [Fact]
    public async Task CreateBook_ShouldCreateBookSuccessfully_WhenAllFieldsAreValid()
    {
        var dto = new CreateBookDto()
        {
            Author = "A",
            Genre = "A",
            Title = "A"
        };

        // Try to create the book and get the result
        var result = (await new LibraryClient(Client).PostBookAsync(dto)).Result;

        // Check that the result matches the input values and an ID was generated
        Assert.Equivalent(result.Author, dto.Author);
        Assert.Equivalent(result.Genre, dto.Genre);
        Assert.Equivalent(result.Title, dto.Title);
        Assert.NotEqual(0, result.Id);
    }

    /// <summary>
    /// Verify that creating a book fails when the author field is empty.
    /// </summary>
    [Fact]
    public async Task CreateBook_ShouldFailToCreateBook_WhenAuthorIsEmpty()
    {
        var dto = new CreateBookDto()
        {
            Author = "", // No author provided
            Genre = "A",
            Title = "A"
        };

        // Check that an ApiException is thrown for missing author
        await Assert.ThrowsAsync<ApiException>(async () => await new LibraryClient(Client).PostBookAsync(dto));
    }

    /// <summary>
    /// Verify that creating a book fails when the genre field is empty.
    /// </summary>
    [Fact]
    public async Task CreateBook_ShouldFailToCreateBook_WhenGenreIsEmpty()
    {
        var dto = new CreateBookDto()
        {
            Author = "A",
            Genre = "", // No genre provided
            Title = "A"
        };

        // Check that an ApiException is thrown for missing genre
        await Assert.ThrowsAsync<ApiException>(async () => await new LibraryClient(Client).PostBookAsync(dto));
    }

    /// <summary>
    /// Verify that creating a book fails when the title field is empty.
    /// </summary>
    [Fact]
    public async Task CreateBook_ShouldFailToCreateBook_WhenTitleIsEmpty()
    {
        var dto = new CreateBookDto()
        {
            Author = "A",
            Genre = "A",
            Title = "" // No title provided
        };

        // Check that an ApiException is thrown for missing title
        await Assert.ThrowsAsync<ApiException>(async () => await new LibraryClient(Client).PostBookAsync(dto));
    }
}
