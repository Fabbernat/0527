export type Category = {
    id: number;
    megnevezes: string;
};

export type RealEstate = {
    id: number;
    kategoriaId: number;
    kategoriaNev: string;
    leiras: string;
    hirdetesDatuma: string;
    tehermentes: boolean;
    kepUrl: string;
};

export type NewRealEstate = {
    kategoriaId: number;
    leiras: string;
    hirdetesDatuma: string;
    tehermentes: boolean;
    kepUrl: string;
};