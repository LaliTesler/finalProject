﻿using AutoMapper;
using DAL.DTO;
using DAL.Interfaces;
using MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class CVData: ICV
    {
        private readonly ModelsContext _Context;
        private readonly IMapper _mapper;

        public CVData(ModelsContext context, IMapper mapper)
        {
            _Context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateCV(CVDTO c)
        {
            await _Context.cv.AddAsync(_mapper.Map <CV> (c));
            await _Context.SaveChangesAsync();
            return true;    
        }

        public async Task<bool> DeleteCV(long id)
        {
            CV c=await _Context.cv.FindAsync (id);
            if (c == null) { return false; }    
            _Context.cv.Remove(c);
            await _Context.SaveChangesAsync();
            return true;
        }

        public async Task<CV>GetCV(long id)
        {
            CV c = await _Context.cv.FindAsync(id);
            if (c == null)
            {
                return null;
            }
            return c;

        }

        public async Task<bool> UpdateCV(long id, CVDTO updatecv)
        {
            CV currentcv = await _Context.cv.FindAsync(id);
            if (currentcv == null) { return false; }
            currentcv.profile = updatecv.profile;
            currentcv.id = id;
            currentcv.mail = updatecv.mail; 
            currentcv.skills=updatecv.skills;
            currentcv.phon=updatecv.phon;   
            currentcv.firstName=updatecv.firstName; 
            currentcv.lastName=updatecv.lastName;
            currentcv.education=updatecv.education;
            currentcv.PracticalExperience=updatecv.PracticalExperience;
            currentcv.language=updatecv.language;

            await _Context.SaveChangesAsync();
            return true;



        }



    }
}