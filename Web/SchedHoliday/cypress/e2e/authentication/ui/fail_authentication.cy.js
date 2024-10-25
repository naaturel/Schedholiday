describe('Try to connect with classic authentication', () => {
    beforeEach(() => {
        cy.visit("http://localhost:5173/connexion")
        cy.get('#email').clear()
        cy.get('#password').clear()

    })



    it('Fail authentication when user doesnt exist', async () => {
        cy.get('#email').type("user-who-doesnt-exist@void.com")
        cy.get('#password').type("This-is-not-a-correct-password")
        await cy.get("form").submit()
        cy.url().should('eq', 'http://localhost:5173/connexion')
    })

    it('Fail authentication by correct email', async () => {
        cy.get('#email').type("user-who-doesnt-exist@void.com")
        cy.get('#password').type("This-is-not-a-correct-password")
        await cy.get("form").submit()
        cy.url().should('eq', 'http://localhost:5173/connexion')
    })

    it('Fail authentication and be locked out', async () => {

        cy.get('#email').type("auva@gmail.com")
        cy.get('#password').type("This-is-not-a-correct-password")

        for (let i = 0; i <= 5; i++){
            await cy.get("form").submit()
        }
        cy.get('#password').clear()
        cy.get('#password').type("Password_123")
        await cy.get("form").submit()
        cy.url().should('eq', 'http://localhost:5173/connexion')
    })
})
