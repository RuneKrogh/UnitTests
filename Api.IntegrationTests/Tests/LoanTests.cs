using Generated;

namespace Api.IntegrationTests.Tests;

public class LoanTests : ApiTestBase
{
    /// <summary>
    /// Verify that a book can be successfully loaned when it is available.
    /// </summary>
    [Fact]
    public async Task LoanBook_ShouldLoanBookSuccessfully_WhenBookIsAvailable()
    {
        var dto = new LoanBookDto()
        {
            BookId = 1, // Assuming this book is available for loan
            UserId = 1
        };

        // Try to loan the book and capture the result
        var result = await new LibraryClient(Client).LoanAsync(dto);
        
        // Verify that the response indicates a successful loan
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode); // Expecting a 200 OK response
    }

    /// <summary>
    /// Verify that loaning a book that does not exist results in an error.
    /// </summary>
    [Fact]
    public async Task LoanBook_ShouldFailToLoanBook_WhenBookDoesNotExist()
    {
        var dto = new LoanBookDto()
        {
            BookId = 9999, // Using a non-existent book ID
            UserId = 1
        };

        // Check that an ApiException is thrown when trying to loan a non-existent book
        await Assert.ThrowsAsync<ApiException>(async () => await new LibraryClient(Client).LoanAsync(dto));
    }

    /// <summary>
    /// Verify that trying to loan a book that is already loaned results in an error.
    /// </summary>
    [Fact]
    public async Task LoanBook_ShouldFailToLoanBook_WhenBookIsAlreadyLoaned()
    {
        var dto = new LoanBookDto()
        {
            BookId = 1, // Assuming this book is already loaned
            UserId = 1
        };

        // First, try to loan the book
        await new LibraryClient(Client).LoanAsync(dto);

        // Now, attempt to loan the same book again and expect an error
        await Assert.ThrowsAsync<ApiException>(async () => await new LibraryClient(Client).LoanAsync(dto));
    }
}