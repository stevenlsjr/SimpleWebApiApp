using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleWebAPIApp;

namespace Tests
{
  class UserModelTest: IDisposable
  {
    public UserModelTest()
    {
      var serviceProvider = new ServiceCollection()
        .AddEntityFrameworkNpgsql()
        .BuildServiceProvider();
      var builder = new DbContextOptionsBuilder<DefaultDbContext>();
    }

    public void Dispose()
    {
    }
  }
}
