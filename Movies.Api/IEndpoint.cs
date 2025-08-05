namespace EditorConfig.Api;

public interface IEndpoint {
  string Tag { get; }
  void Map(IEndpointRouteBuilder builder);
}
