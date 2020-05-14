﻿using KanbanBoard.Data.Entities;
using KanbanBoard.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoard.Services
{
    public class MainService
    {
        IRepository<ApplicationUser> userRepo;
        IRepository<JobColumn> columnsRepo;
        IRepository<JobItem> itemsRepo;

        public MainService(IRepository<ApplicationUser> userRepository,
            IRepository<JobColumn> columnsRepository,
            IRepository<JobItem> jobRepository)
        {                           
            userRepo = userRepository;
            columnsRepo = columnsRepository;
            itemsRepo = jobRepository;
        }


        public async Task<List<ApplicationUser>> GetAllUsers() {
            var users = await userRepo.GetAll();
            return users.ToList();
        }

        public async Task<List<JobColumn>> GetColumns()
        {
            var columns = await columnsRepo
                .AsQueryable()
                .Include(x => x.JobItems)
                .ToListAsync();
            return columns.ToList();
        }

        public async Task<JobColumn> AddColumn(JobColumn column)
        {
            return await this.columnsRepo.Add(column);
        }

        public async Task<JobItem> AddItem(JobItem item)
        {
            return await this.itemsRepo.Add(item);
        }

        public async Task<JobItem> UpdateJobItem(JobItem item)
        {
            return await this.itemsRepo.Update(item);
        }

    }
}