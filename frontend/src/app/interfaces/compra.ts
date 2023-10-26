export interface Compra {
    idPurchase:   number | null;
    purchaseDate: Date | null;
    quantity:     number;
    total:        number;
    idPerson:     number;
    symbol:       string;
}