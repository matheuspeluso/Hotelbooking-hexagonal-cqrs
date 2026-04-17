using NUnit.Framework;
using Domain.Entities;
using Domain.Enums;
using Action = Domain.Enums.Action;

namespace DomainTests.Bookings
{
    public class StateMachineTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShoudAlwaysStartWithCreatedStatus() //deve sempre iniciar com o status criado
        {
            var booking = new Booking();
            Assert.AreEqual(Status.Created, booking.CurrentStatus);
        }

        [Test]
        public void ShoudSetStatusToPaidWhenPayingForBookingWithCreatedStatus() //deve mudar o status para pago quando pagar uma reserva com o status criado
        {
            var booking = new Booking();
            booking.ChangeState(Action.Pay);
            Assert.AreEqual(Status.Paid, booking.CurrentStatus);
        }

        [Test]
        public void ShoudSetStatusToCanceledWhenCancellingBookingWithCreatedStatus() //deve mudar o status para cancelado quando cancelar uma reserva com o status criado
        {
            var booking = new Booking();
            booking.ChangeState(Action.Cancel);
            Assert.AreEqual(Status.Cancelled , booking.CurrentStatus);
        }

        [Test]
        public void ShoudSetStatusToFinishedWhenFinishingBookingWithPaidStatus() //deve mudar o status para finalizado quando finalizar uma reserva com o status pago
        {
            var booking = new Booking();
            booking.ChangeState(Action.Pay); //mudar o status para pago para poder finalizar
            booking.ChangeState(Action.Finish);
            Assert.AreEqual(Status.Finished, booking.CurrentStatus);
        }

        [Test]
        public void ShoudSetStatusRefoundedWhenRefoundingBookingWithPaidStatus() //deve mudar o status para reembolsado quando reembolsar uma reserva com o status pago
        {
            var booking = new Booking();
            booking.ChangeState(Action.Pay); //mudar o status para pago para poder finalizar
            booking.ChangeState(Action.Refound);
            Assert.AreEqual(Status.Refounded, booking.CurrentStatus);
        }

        [Test]
        public void ShoudSetStatusCreatedWhenReopeningBookingWithCancelledStatus() //deve mudar o status para criado quando reabrir uma reserva com o status cancelado
        {
            var booking = new Booking();
            booking.ChangeState(Action.Cancel); //mudar o status para cancelado para poder reabrir
            booking.ChangeState(Action.Reopen);
            Assert.AreEqual(Status.Created, booking.CurrentStatus);
        }

        //Negative Tests
        [Test]
        public void ShoudContinueWithStatusCreatedWhenRefoundingBookingWithCreatedStatus() //deve continuar com o status criado quando reembolsar uma reserva com o status criado
        {
            var booking = new Booking();
            booking.ChangeState(Action.Refound);
            Assert.AreEqual(Status.Created, booking.CurrentStatus);
        }

        [Test]
        public void ShoudContinueWithStatusFinishedWhenRefoundingBookingWithFinishedStatus() //deve continuar com o status criado quando reembolsar uma reserva com o status criado
        {
            var booking = new Booking();
            booking.ChangeState(Action.Pay); //mudar o status para pago para poder finalizar
            booking.ChangeState(Action.Finish); //mudar o status para finalizado para poder reembolsar
            //tentando reembolsar uma reserva com status finalizado, o status deve continuar como finalizado
            booking.ChangeState(Action.Refound);
            Assert.AreEqual(Status.Finished, booking.CurrentStatus);
        }
    }
}