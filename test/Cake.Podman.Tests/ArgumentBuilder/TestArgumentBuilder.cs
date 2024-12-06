namespace Cake.Podman.Tests.ArgumentBuilder;

public class TestArgumentBuilder
{

    private const string ARGUMENT = "argument";

    [Fact]
    public void Test_Argument()
    {
        var fixture = new PodmanTestFixture
        {
            Argument = ARGUMENT
        };

        var actual = fixture.Run();

        Assert.Equal($"test {ARGUMENT}", actual.Args);
    }

    [Fact]
    public void Test_Bool_Option()
    {
        var fixture = new PodmanTestFixture
        {
            Settings = new PodmanTestOptions
            {
                BoolProperty = true
            }
        };

        var actual = fixture.Run();

        Assert.Equal("test --bool-option ", actual.Args);
    }

    [Fact]
    public void Test_Bool_Option_With_Argument()
    {
        var fixture = new PodmanTestFixture
        {
            Argument = ARGUMENT,
            Settings = new PodmanTestOptions
            {
                BoolProperty = true
            }
        };

        var actual = fixture.Run();

        Assert.Equal($"test --bool-option  {ARGUMENT}", actual.Args);
    }

    [Fact]
    public void Test_Int_Option()
    {
        var fixture = new PodmanTestFixture
        {
            Settings = new PodmanTestOptions
            {
                IntProperty = 30
            }
        };

        var actual = fixture.Run();

        Assert.Equal("test --int-option 30", actual.Args);
    }

    [Fact]
    public void Test_Int_Option_With_Argument()
    {
        var fixture = new PodmanTestFixture
        {
            Argument = ARGUMENT,
            Settings = new PodmanTestOptions
            {
                IntProperty = 30
            }
        };

        var actual = fixture.Run();

        Assert.Equal($"test --int-option 30 {ARGUMENT}", actual.Args);
    }

    [Fact]
    public void Test_String_Option()
    {
        var fixture = new PodmanTestFixture
        {
            Settings = new PodmanTestOptions
            {
                StringProperty = "s1/s2:s3"
            }
        };

        var actual = fixture.Run();

        Assert.Equal("test --string-option s1/s2:s3", actual.Args);
    }

    [Fact]
    public void Test_String_Option_Wirh_Argument()
    {
        var fixture = new PodmanTestFixture
        {
            Argument = ARGUMENT,
            Settings = new PodmanTestOptions
            {
                StringProperty = "s1/s2:s3"
            }
        };

        var actual = fixture.Run();

        Assert.Equal($"test --string-option s1/s2:s3 {ARGUMENT}", actual.Args);
    }

    [Fact]
    public void Test_StringArray_Option_Multiple()
    {
        var fixture = new PodmanTestFixture
        {
            Settings = new PodmanTestOptions
            {
                StringArrayMultipleProperty = ["s1", "s2", "s3"]
            }
        };

        var actual = fixture.Run();

        Assert.Equal("test --array-multi-option s1 --array-multi-option s2 --array-multi-option s3", actual.Args);
    }

    [Fact]
    public void Test_StringArray_Option_Multiple_With_Argument()
    {
        var fixture = new PodmanTestFixture
        {
            Argument = ARGUMENT,
            Settings = new PodmanTestOptions
            {
                StringArrayMultipleProperty = ["s1", "s2", "s3"]
            }
        };

        var actual = fixture.Run();

        Assert.Equal($"test --array-multi-option s1 --array-multi-option s2 --array-multi-option s3 {ARGUMENT}", actual.Args);
    }

    [Fact]
    public void Test_StringArray_Option_CSV()
    {
        var fixture = new PodmanTestFixture
        {
            Settings = new PodmanTestOptions
            {
                StringArrayCsvProperty = ["s1", "s2", "s3"]
            }
        };

        var actual = fixture.Run();

        Assert.Equal("test --array-csv-option s1,s2,s3", actual.Args);
    }

    [Fact]
    public void Test_StringArray_Option_CSV_With_Argument()
    {
        var fixture = new PodmanTestFixture
        {
            Argument = ARGUMENT,
            Settings = new PodmanTestOptions
            {
                StringArrayCsvProperty = ["s1", "s2", "s3"]
            }
        };

        var actual = fixture.Run();

        Assert.Equal($"test --array-csv-option s1,s2,s3 {ARGUMENT}", actual.Args);
    }    
}