using DotNet.FunctionalExtensions.Interfaces;
using DotNet.FunctionalExtensions.Services;
using FluentAssertions;
using NUnit.Framework;
using QuickChecks.ContentProcessing.Dto;
using QuickChecks.ContentProcessing.Dto.InnerDto;
using QuickChecks.ContentProcessing.Interfaces;
using QuickChecks.ContentProcessing.Services;

namespace QuickChecks.ContentProcessing.Tests;

public class PollContentSerializerTests
{
    private const string PollTemplatePath = "TestData/pollTemplate.yaml";

    private ISerializerFactory serializerFactory;
    private PollContentSerializer pollContentSerializer;

    private IAssemblyFileReader assemblyFileReader;

    [SetUp]
    public void Setup()
    {
        assemblyFileReader = new AssemblyFileReader();

        serializerFactory = new SerializerFactory();
        pollContentSerializer = new PollContentSerializer(serializerFactory);
    }

    [Test]
    public void DeserializePollContent_When_ContentValid_Return_ExpectedResult()
    {
        var expected = GetPollContent();

        var content = assemblyFileReader.GetFileFromCurrentAssembly(PollTemplatePath);
        var actual = pollContentSerializer.DeserializePollContent(content);

        actual.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void SerializePollContent_When_ContentValid_Return_ExpectedResult()
    {
        var expected = assemblyFileReader.GetFileFromCurrentAssembly(PollTemplatePath);

        var pollContent = GetPollContent();
        var actual = pollContentSerializer.SerializePollContent(pollContent);

        actual.Should().BeEquivalentTo(expected);
    }

    private PollContentDto GetPollContent()
    {
        var result = new PollContentDto
        {
            Categories = new[]
            {
                new ParsedCategoryDto
                {
                    Name = "category1",
                    Questions = new[]
                    {
                        new ParsedQuestionDto
                        {
                            TypeId = 1,
                            IsRequired = true,
                            Content = "what about ...?",
                            Options = new[]
                            {
                                new ParsedQuestionOptionDto
                                {
                                    Content = "a.",
                                    Score = 10
                                },
                                new ParsedQuestionOptionDto
                                {
                                    Content = "b,",
                                    Score = 20
                                },
                                new ParsedQuestionOptionDto
                                {
                                    Content = "c",
                                    Score = 30
                                }
                            }
                        },
                        new ParsedQuestionDto
                        {
                            TypeId = 1,
                            IsRequired = true,
                            Content = "what if ...?",
                            Options = new[]
                            {
                                new ParsedQuestionOptionDto
                                {
                                    Content = "d.",
                                    Score = 10
                                }
                            }
                        }
                    }
                },
                new ParsedCategoryDto
                {
                    Name = "category2",
                    Questions = new[]
                    {
                        new ParsedQuestionDto
                        {
                            TypeId = 2,
                            IsRequired = true,
                            Content = "what about2 ...?",
                            Options = new[]
                            {
                                new ParsedQuestionOptionDto
                                {
                                    Content = "a.",
                                    Score = 10
                                },
                                new ParsedQuestionOptionDto
                                {
                                    Content = "b,",
                                    Score = 20
                                }
                            }
                        }
                    }
                }
            }
        };

        return result;
    }
}