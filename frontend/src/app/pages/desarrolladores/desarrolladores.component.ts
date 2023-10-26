import { Component } from '@angular/core';
import { Developer } from 'src/app/interfaces/developer.interfaces';

@Component({
  selector: 'app-desarrolladores',
  templateUrl: './desarrolladores.component.html',
  styleUrls: ['./desarrolladores.component.css']
})
export class DesarrolladoresComponent {

  public developers: Developer[] = [
    {
      foto: "../../../assets/team/felipe.jpeg",
      nombre: "Felipe Primo Rivera",
      ocupacion: "Full Stack",
      links: [
        {
          logo: "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/github/github-original.svg",
          link: "https://github.com/FeliPrimo25",
          muestra: "GitHub",
          alt: "github logo"
        },
        {
          logo: "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/linkedin/linkedin-original.svg",
          link: "https://www.linkedin.com/in/felipe-primo-rivera-b43105256/",
          muestra: "LinkedIn",
          alt: "linkedin logo"
        }

      ]
    },
    {
      foto: "../../../assets/team/carnet.jpg",
      nombre: "Diego Guzmán",
      ocupacion: "Front End",
      links: [
        {
          logo: "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/github/github-original.svg",
          link: "https://github.com/cerveux",
          muestra: "GitHub",
          alt: "github logo"
        },
        {
          logo: "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/linkedin/linkedin-original.svg",
          link: "https://www.linkedin.com/in/diego-guzm%C3%A1n-cerveux/",
          muestra: "LinkedIn",
          alt: "linkedin logo"
        },
        {
          logo: "https://www.svgrepo.com/show/39138/portfolio.svg",
          link: "https://cerveux.dev.ar/",
          muestra: "Portfolio",
          alt: "portfolio logo"
        }

      ]
    },
    {
      foto: "../../../assets/team/santiago.jpg",
      nombre: "Santiago Clemenzi",
      ocupacion: "Back End",
      links: [
        {
          logo: "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/github/github-original.svg",
          link: "https://github.com/SantiClemenzi",
          muestra: "GitHub",
          alt: "github logo"
        },
        {
          logo: "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/linkedin/linkedin-original.svg",
          link: "https://www.linkedin.com/in/santiagoclemenzi-developer/",
          muestra: "LinkedIn",
          alt: "linkedin logo"
        },

      ]
    },
    // {
    //   foto: "../../../assets/team/Clarisa.jpg",
    //   nombre: "Clarisa Negro",
    //   ocupacion: "Full-Stack",
    //   links: [
    //     {
    //       logo: "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/github/github-original.svg",
    //       link: "https://github.com/NegroClari",
    //       muestra: "GitHub",
    //       alt: "github logo"
    //     },
    //     {
    //       logo: "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/linkedin/linkedin-original.svg",
    //       link: "http://linkedin.com/in/clarisa-negro-78353015b",
    //       muestra: "LinkedIn",
    //       alt: "linkedin logo"
    //     },

    //   ]
    // },
    // {
    //   foto: "../../../assets/team/flavio.jpg",
    //   nombre: "Flavio Saldaña",
    //   ocupacion: "Full-Stack",
    //   links: [
    //     {
    //       logo: "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/github/github-original.svg",
    //       link: "https://github.com/flaviogastonok",
    //       muestra: "GitHub",
    //       alt: "github logo"
    //     },
    //     {
    //       logo: "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/linkedin/linkedin-original.svg",
    //       link: "https://www.linkedin.com/in/flaviogastonsalda%C3%B1a1988",
    //       muestra: "LinkedIn",
    //       alt: "linkedin logo"
    //     },

    //   ]
    // },
    {
      foto: "../../../assets/team/gaspar.jpg",
      nombre: "Gaspar Bosch",
      ocupacion: "Back End",
      links: [
        {
          logo: "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/github/github-original.svg",
          link: "https://github.com/GasparB123",
          muestra: "GitHub",
          alt: "github logo"
        },
        {
          logo: "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/linkedin/linkedin-original.svg",
          link: "https://www.linkedin.com/in/gaspar-bosch-198968151/",
          muestra: "LinkedIn",
          alt: "linkedin logo"
        },

      ]
    },
    {
      foto: "../../../assets/team/38b9b79b-3fb9-4c6c-8a32-9b4a890b4ac2.jpeg",
      nombre: "Diego Arias Rojo",
      ocupacion: "Back End",
      links: [
        {
          logo: "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/github/github-original.svg",
          link: "https://github.com/DiegoArias95",
          muestra: "GitHub",
          alt: "github logo"
        }

      ]
    },
  ]

}
