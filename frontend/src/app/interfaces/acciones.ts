export interface Acciones {
    titulos: Titulo[];
}

export interface Titulo {
    simbolo:             string;
    puntas:              Puntas | null;
    ultimoPrecio:        number;
    variacionPorcentual: number;
    apertura:            number;
    maximo:              number;
    minimo:              number;
    ultimoCierre:        number;
    volumen:             number;
    cantidadOperaciones: number;
    fecha:               Date;
    tipoOpcion:          null;
    precioEjercicio:     null;
    fechaVencimiento:    null;
    mercado:             string;
    moneda:              string;
    descripcion:         string;
    plazo:               Plazo;
    laminaMinima:        number;
    lote:                number;
}

export enum Plazo {
    T2 = "T2",
}

export interface Puntas {
    cantidadCompra: number;
    precioCompra:   number;
    precioVenta:    number;
    cantidadVenta:  number;
}
