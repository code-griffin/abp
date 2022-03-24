// This file is automatically generated by ABP framework to use MVC Controllers from CSharp
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client.ClientProxying;
using Volo.CmsKit.Admin.Blogs;

// ReSharper disable once CheckNamespace
namespace Volo.CmsKit.Admin.Blogs.ClientProxies;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(IBlogPostAdminAppService), typeof(BlogPostAdminClientProxy))]
public partial class BlogPostAdminClientProxy : ClientProxyBase<IBlogPostAdminAppService>, IBlogPostAdminAppService
{
    public virtual async Task<BlogPostDto> CreateAsync(CreateBlogPostDto input)
    {
        return await RequestAsync<BlogPostDto>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(CreateBlogPostDto), input }
        });
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        await RequestAsync(nameof(DeleteAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<BlogPostDto> GetAsync(Guid id)
    {
        return await RequestAsync<BlogPostDto>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<PagedResultDto<BlogPostListDto>> GetListAsync(BlogPostGetListInput input)
    {
        return await RequestAsync<PagedResultDto<BlogPostListDto>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(BlogPostGetListInput), input }
        });
    }

    public virtual async Task<BlogPostDto> UpdateAsync(Guid id, UpdateBlogPostDto input)
    {
        return await RequestAsync<BlogPostDto>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(UpdateBlogPostDto), input }
        });
    }
    
    public virtual async Task PublishAsync(Guid id)
    {
        await RequestAsync(nameof(PublishAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
        });
    }
    
}
