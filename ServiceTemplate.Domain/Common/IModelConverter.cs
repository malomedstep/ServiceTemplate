namespace ServiceTemplate.Domain.Common
{
    public interface IModelConverter<in TFrom, out TTo>
    {
        public TTo Convert(TFrom source);
    }
}