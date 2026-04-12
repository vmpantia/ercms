namespace ERCMS.Domain.Interfaces;

public interface IMappable<out TDestination> 
    where TDestination : class
{
    TDestination Map();
}