﻿using Business.Abstract;
using Entities.Concrete;
using MernisServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    //Çıplak class kalmasın 
    public class PersonMenager : IapplicantService
    {
        public void ApplyForMask(Person person)
        {
          

        }
        public List<Person> GetList()
        {
            return null;
        }

     public bool CheckPerson(Person person)//mernis kontrolu yapılıyor
        {
            KPSPublicSoapClient client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            return client.TCKimlikNoDogrulaAsync(new TCKimlikNoDogrulaRequest
        (new TCKimlikNoDogrulaRequestBody(person.NationalIdentity, Ad:person.FirstName, Soyad: person.LastName, DogumYili:person.DateOfBirthYear )))
            .Result.Body.TCKimlikNoDogrulaResult;
        }


    }
}
