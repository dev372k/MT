﻿using Application.Abstractions.Interfaces;
using Application.DTOs;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Application.Abstractions.Implementations
{
    public class GroupRepo : IGroupRepo
    {
        private ApplicationDBContext _context;

        public GroupRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public void Add(int userId, AddGroupDTO dto)
        {
            var group = new Persistence.Entities.Group
            {
                Name = dto.Name,
                CreatedOn = DateTime.Now,
                UserId = userId
            };
            _context.Groups.Add(group);
            _context.SaveChanges();
        }

        public void Update(int userId, UpdateGroupDTO dto)
        {
            var group = _context.Groups.FirstOrDefault(_ => _.Id == dto.Id);

            if (group != null)
            {
                group.Name = dto.Name;
                group.UpdatedOn = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public GetGroupDTOs Get(int userId, int pageNo, int pageSize, string search)
        {
            var query = _context.Groups.Where(_ => _.UserId == userId).AsQueryable();
            var groups = query
                .Where(_ => !string.IsNullOrEmpty(search) ? _.Name.ToLower().Contains(search.ToLower()) : true)
                .Select(_ => new GetGroupDTO
                {
                    Id = _.Id,
                    Name = _.Name,
                    CreatedOn = _.CreatedOn.ToString("dd MMMM, yyyy")
                }).OrderByDescending(_ => _.Id).Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();


            return new GetGroupDTOs
            {
                Item = groups,
                PageNo = pageNo,
                PageSize = pageSize,
                TotalCount = string.IsNullOrEmpty(search) ? query.Count() : groups.Count()
            };
        }

        public void Delete(int id)
        {
            var group = _context.Groups.FirstOrDefault(_ => _.Id == id);

            if (group != null)
            {
                group.IsDeleted = true;
                _context.SaveChanges();
            }
        }

        public List<SelectListItem> Get(int userId)
        {
            return _context.Groups
                .Where(_ => _.UserId == userId)
                .Select(_ => new SelectListItem
                {
                    Value = _.Id.ToString(),
                    Text = _.Name,
                }).ToList();
        }
    }
}